using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models.Domain
{
     public class Employee
     {
          public int Id { get; set; }
          public string? Name { get; set; }
          public string? Email { get; set; }
          public DateTime BirthDate { get; set; }
          public int DepartmentId { get; set; }
          public Department Department { get; set; }
     }
}
