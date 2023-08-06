using Project.Models.Domain;

namespace Project.Models
{
     public class AddEmployessViewModel
     {
          public string? Name { get; set; }
          public string? Email { get; set; }
          public DateTime BirthDate { get; set; }
          public Department Department { get; set; }
     }
}
