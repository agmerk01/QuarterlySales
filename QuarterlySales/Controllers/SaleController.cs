using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuarterlySales.Models;

namespace QuarterlySales.Controllers
{
    public class SaleController : Controller
    {
        private SaleRecordContext Context { get; set; }
        public SaleController(SaleRecordContext ctx)
        {
            Context = ctx;
        }
        [HttpGet]
        public IActionResult AddSale()
        {
            ViewBag.Employees = Context.Employees.OrderBy(e => e.Lname).ToList();
            return View("AddSale", new SaleRecord());
        }
        [HttpPost]
        public IActionResult AddSale(SaleRecord saleRecord)
        {
            if (ModelState.IsValid)
            {
                Context.SaleRecords.Add(saleRecord);
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = Context.Employees.OrderBy(e => e.Lname).ToList();
                return View("AddSale", new SaleRecord());
            }
        }
    }
}
