using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_Employees1.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Companies",
               columns: new[] { "CompanyId", "adresse", "country", "name" },
               values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Rabat", "Maroc", "SQLI" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "adresse", "country", "name" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "rabat", "Maroc", "Concepment" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "position" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 23, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Hicham", "Software Enginere" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "position" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 24, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Ahmed", "Software Developer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
               table: "Employees",
               keyColumn: "EmployeeId",
               keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
