using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public class SaleRecord
    {
        public int SaleRecordID { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public double Amount { get; set; }
    }
}
