using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuarterlySales.Models;
using Microsoft.EntityFrameworkCore;

namespace QuarterlySales.Controllers
{
    public class HomeController : Controller
    {
        private SaleRecordContext Context { get; set; }
        public HomeController(SaleRecordContext ctx)
        {
            Context = ctx;
        }
        public IActionResult Index(int id=0)
        {
            if (id > 0) {
                SalesListModelView slmv = new SalesListModelView();
                slmv.Employees = Context.Employees.OrderBy(e => e.Lname).ToList();
                slmv.Sales= Context.SaleRecords.Where(e => e.EmployeeID == id).Include(e => e.Employee).OrderBy(y => y.Employee.Lname).ToList();
                slmv.EmployeeID = id;
                //ViewBag.Employees = Context.Employees.OrderBy(e => e.Lname).ToList();
                //var sales = Context.SaleRecords.Where(e=>e.EmployeeID==id).Include(e => e.Employee).OrderBy(y => y.Employee.Lname).ToList();
                return View(slmv);
            }
            else
            {
                SalesListModelView slmv = new SalesListModelView();
                slmv.Employees= Context.Employees.OrderBy(e => e.Lname).ToList();
                slmv.Sales= Context.SaleRecords.Include(e => e.Employee).OrderBy(y => y.Employee.Lname).ToList();
                slmv.EmployeeID = 0;
                //ViewBag.Employees = Context.Employees.OrderBy(e => e.Lname).ToList();
                //var sales = Context.SaleRecords.Include(e => e.Employee).OrderBy(y => y.Employee.Lname).ToList();
                return View(slmv);
            }
        }
        [HttpPost]
        public RedirectToActionResult Index(Employee employee)
        {
            if (employee.EmployeeID > 0)
                return RedirectToAction("Index", new { id = employee.EmployeeID });
            else
                // pass empty string for id segment to clear any previous values
                return RedirectToAction("Index", new { id = "" });
        }
    }
}
