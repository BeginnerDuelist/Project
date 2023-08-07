using Project.Service.Interface;
using System.Text.RegularExpressions;

namespace Project.Service
{
     public class EmployeeService : IEmployeeService
     {
          public void validateEmail(string email)
          {
               string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
               Match email1 = Regex.Match(email, emailPattern);
                    
               if (!email1.Success)
               {
                   throw new Exception("Invalid email!");
               }

               
          
     }
     }
}
