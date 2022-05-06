using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuarterlySales.Models;
namespace QuarterlySales.Controllers
{
    public class EmployeeController : Controller
    {
        private SaleRecordContext Context { get; set; }
        public EmployeeController(SaleRecordContext ctx)
        {
            Context = ctx;
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            ViewBag.Managers = Context.Managers.OrderBy(m => m.FullName).ToList();
            ViewBag.Employees = Context.Employees.OrderBy(e => e.Lname).ToList();
            return View("AddEmployee", new Employee());
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            ViewBag.Employees = Context.Employees.OrderBy(e => e.Lname).ToList();
            bool isNewEmp = true;
            foreach (Employee e in ViewBag.Employees)
            {
                if (employee.FName == e.FName && employee.Lname==e.Lname && employee.DOB == e.DOB)
                {
                    isNewEmp = false;
                }
            }
            if (ModelState.IsValid&&isNewEmp)
            {
                Context.Employees.Add(employee);
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Managers= Context.Managers.OrderBy(m => m.FullName).ToList();
                return View("AddEmployee", new Employee());
            }
        }
    }
}
