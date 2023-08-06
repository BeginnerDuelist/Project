namespace Project.Models.Domain
{
     public class Department
     {
          public int DepartmentId { get; set; }
          public string Name { get; set; }
          public string Description { get; set; }
          public ICollection<Employee> Employees { get; set; }


     }
}
