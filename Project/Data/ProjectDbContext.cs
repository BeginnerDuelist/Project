using Microsoft.EntityFrameworkCore;
using Project.Models.Domain;

namespace Project.Data
{
     public class ProjectDbContext:DbContext
     {
          public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

          public DbSet<Employee> Employees { get; set; }


     }
}
