using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public class SalesListModelView
    {
        public List<SaleRecord> Sales {get;set;}
        public List<Employee> Employees { get; set; }
        public int EmployeeID { get; set; }
    }
}
