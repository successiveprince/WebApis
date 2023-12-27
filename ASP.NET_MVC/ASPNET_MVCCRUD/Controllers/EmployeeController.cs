using ASPNET_MVCCRUD.Data;
using ASPNET_MVCCRUD.Models;
using ASPNET_MVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ASPNET_MVCCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MVCDbContext mvcDbContext;
        public EmployeeController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            var employee = await mvcDbContext.Employee.ToListAsync();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new MyEmployee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                Department = addEmployeeRequest.Department
               
            };
            await mvcDbContext.Employee.AddAsync(employee);
            await mvcDbContext.SaveChangesAsync();  
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var emp = await mvcDbContext.Employee.FirstOrDefaultAsync(x => x.Id == id);

            if (emp != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Email = emp.Email,
                    Salary = emp.Salary,
                    DateOfBirth = emp.DateOfBirth,
                    Department = emp.Department
                };
                return await Task.Run(() =>  View("View" ,viewModel));
            }
            return RedirectToAction("Index");

           
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var emp = await mvcDbContext.Employee.FindAsync(model.Id);

            if(emp != null)
            {
                emp.Name = model.Name;
                emp.Email = model.Email;
                emp.Salary = model.Salary;
                emp.DateOfBirth = model.DateOfBirth;
                emp.Department = model.Department;

                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var emp = await mvcDbContext.Employee.FindAsync(model.Id);

            if(emp != null)
            {
                mvcDbContext.Employee.Remove(emp);
                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}
