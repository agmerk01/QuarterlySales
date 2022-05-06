using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace QuarterlySales.Models
{
    public class Employee
    {
        public string FName { get; set; }
        public string Lname { get; set; }
        public int EmployeeID { get; set; }
        public Manager Manager { get; set; }
        public int ManagerID { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime DOB { get; set;}

    }
}
