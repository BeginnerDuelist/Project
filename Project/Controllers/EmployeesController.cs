using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.Domain;

namespace proiect.Controllers
{
     public class EmployeesController : Controller
     {
          private readonly ProjectDbContext projectDbContext;

          public EmployeesController(ProjectDbContext projectDbContext)
          {
               this.projectDbContext = projectDbContext;
          }
          [HttpGet]
          public async Task<IActionResult> Index()
          {
               var employees = await projectDbContext.Employees.ToListAsync();
               return View(employees);

          }
          [HttpGet]
          public IActionResult Add()
          {
               return View();
          }

          [HttpPost]
          public async Task<IActionResult> Add(AddEmployessViewModel addEmployeesRequest)
          {
               var employee = new Employee()
               {
                    Id = Guid.NewGuid(),
                    Name = addEmployeesRequest.Name,
                    Email = addEmployeesRequest.Email,
                    BirthDate = addEmployeesRequest.BirthDate,
                    Department = addEmployeesRequest.Department

               };
               await projectDbContext.Employees.AddAsync(employee);
               await projectDbContext.SaveChangesAsync();
               return RedirectToAction("Add");

          }
          [HttpGet]
          public async Task<IActionResult> View(Guid id)
          {
               var employee = await projectDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
               if (employee != null)
               {
                    var viewModel = new UpdateEmployeeViewModel()
                    {
                         Id = employee.Id,
                         Name = employee.Name,
                         Email = employee.Email,
                         BirthDate = employee.BirthDate,
                         Department = employee.Department
                    };
                    return await Task.Run(() => View("View", viewModel));
               }
               return RedirectToAction("Index");
          }
          [HttpPost]
          public async Task<IActionResult> View(UpdateEmployeeViewModel model)
          {
               var employee = await projectDbContext.Employees.FindAsync(model.Id);
               if (employee != null)
               {
                    employee.Name = model.Name;
                    employee.Email = model.Email;
                    employee.BirthDate = model.BirthDate;
                    employee.Department = model.Department;


                    await projectDbContext.SaveChangesAsync();

                    return RedirectToAction("Index");
               }
               return RedirectToAction("Index");

          }

          [HttpPost]
          public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
          {
               var employee = await projectDbContext.Employees.FindAsync(model.Id);

               if (employee != null)
               {
                    projectDbContext.Employees.Remove(employee);
                    await projectDbContext.SaveChangesAsync();


                    return RedirectToAction("Index");
               }
               return RedirectToAction("Index");
          }
     }


}
