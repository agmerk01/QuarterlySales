using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuarterlySales.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    ManagerID = table.Column<int>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Managers_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Managers",
                        principalColumn: "ManagerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleRecords",
                columns: table => new
                {
                    SaleRecordID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Quarter = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleRecords", x => x.SaleRecordID);
                    table.ForeignKey(
                        name: "FK_SaleRecords_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerID", "FullName" },
                values: new object[] { 1, "Clark Stanford" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerID", "FullName" },
                values: new object[] { 2, "Dag Romero" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DOB", "FName", "HireDate", "Lname", "ManagerID" },
                values: new object[] { 1, new DateTime(1972, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeremy", new DateTime(1996, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leights", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DOB", "FName", "HireDate", "Lname", "ManagerID" },
                values: new object[] { 2, new DateTime(1952, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stanley", new DateTime(1996, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medleys", 2 });

            migrationBuilder.InsertData(
                table: "SaleRecords",
                columns: new[] { "SaleRecordID", "Amount", "EmployeeID", "Quarter", "Year" },
                values: new object[] { 1, 12000.719999999999, 1, 2, 2001 });

            migrationBuilder.InsertData(
                table: "SaleRecords",
                columns: new[] { "SaleRecordID", "Amount", "EmployeeID", "Quarter", "Year" },
                values: new object[] { 2, 1883.45, 2, 3, 1997 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerID",
                table: "Employees",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleRecords_EmployeeID",
                table: "SaleRecords",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleRecords");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
