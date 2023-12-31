﻿using Project.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
     public class UpdateEmployeeViewModel
     {
          public Guid Id { get; set; }
          public string Name { get; set; }
          public string Email { get; set; }
          public DateTime BirthDate { get; set; }
          public Department Department { get; set; }
     }
}
