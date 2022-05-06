using Microsoft.EntityFrameworkCore;

namespace QuarterlySales.Models
{
    public class SaleRecordContext : DbContext
    {
        public SaleRecordContext(DbContextOptions<SaleRecordContext> options)
        : base(options)
        { }
        public DbSet<SaleRecord> SaleRecords { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().HasData(
                new Manager { ManagerID = 1, FullName = "Clark Stanford" },
                new Manager { ManagerID = 2, FullName = "Dag Romero" }
                );
            modelBuilder.Entity<Employee>().HasData(
                 new Employee { EmployeeID=1,FName="Jeremy",Lname ="Leights",HireDate=new System.DateTime(1996,1,3), DOB=new System.DateTime(1972,7,2),ManagerID=1},
                 new Employee { EmployeeID = 2,FName = "Stanley",Lname = "Medleys",HireDate = new System.DateTime(1996, 4, 5), DOB = new System.DateTime(1952, 2, 1),ManagerID = 2}
                 );
            modelBuilder.Entity<SaleRecord>().HasData(
                new SaleRecord { SaleRecordID = 1, Amount = 12000.72, EmployeeID = 1, Quarter = 2, Year = 2001 },
                new SaleRecord { SaleRecordID=2,Amount=1883.45,EmployeeID=2,Quarter=3,Year=1997}
                );
        }
    }
}
