using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind_Example.Models;

namespace Northwind_Example.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly NorthwindDbContext _context;

        public EmployeeController(NorthwindDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<Employee> list = _context.Employees.ToList();
            return View(list);
        }
        public IActionResult Details(int id)
        {
            Employee employee = _context.Employees.Find(id);
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            Employee employee = _context.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            Employee editemployee = new Employee()
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Title = employee.Title,
                BirthDate = employee.BirthDate,
                Address = employee.Address,
                City = employee.City,
                Country = employee.Country,
                HomePhone = employee.HomePhone,
                Extension = employee.Extension
            };
            _context.Employees.Update(editemployee);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
