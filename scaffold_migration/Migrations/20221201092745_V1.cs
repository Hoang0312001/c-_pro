using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scaffoldmigration.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEPARTMENT",
                columns: table => new
                {
                    DEPTID = table.Column<int>(name: "DEPT_ID", type: "int", nullable: false),
                    DEPTNAME = table.Column<string>(name: "DEPT_NAME", type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    DEPTNO = table.Column<string>(name: "DEPT_NO", type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LOCATION = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DEPARTME__512A59AC999F51A7", x => x.DEPTID);
                });

            migrationBuilder.CreateTable(
                name: "SALARY_GRADE",
                columns: table => new
                {
                    GRADE = table.Column<int>(type: "int", nullable: false),
                    HIGHSALARY = table.Column<double>(name: "HIGH_SALARY", type: "float", nullable: false),
                    LOWSALARY = table.Column<double>(name: "LOW_SALARY", type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SALARY_G__B80884C7ED963CFA", x => x.GRADE);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    EMPID = table.Column<decimal>(name: "EMP_ID", type: "numeric(19,0)", nullable: false),
                    EMPNAME = table.Column<string>(name: "EMP_NAME", type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    EMPNO = table.Column<string>(name: "EMP_NO", type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    HIREDATE = table.Column<DateTime>(name: "HIRE_DATE", type: "datetime", nullable: false),
                    IMAGE = table.Column<byte[]>(type: "image", nullable: true),
                    JOB = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    SALARY = table.Column<double>(type: "float", nullable: false),
                    DEPTID = table.Column<int>(name: "DEPT_ID", type: "int", nullable: false),
                    MNGID = table.Column<decimal>(name: "MNG_ID", type: "numeric(19,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EMPLOYEE__16EBFA26083DB420", x => x.EMPID);
                    table.ForeignKey(
                        name: "FK75C8D6AE13C12F64",
                        column: x => x.MNGID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EMP_ID");
                    table.ForeignKey(
                        name: "FK75C8D6AE269A3C9",
                        column: x => x.DEPTID,
                        principalTable: "DEPARTMENT",
                        principalColumn: "DEPT_ID");
                });

            migrationBuilder.CreateTable(
                name: "TIMEKEEPER",
                columns: table => new
                {
                    TimekeeperId = table.Column<string>(name: "Timekeeper_Id", type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    DateTime = table.Column<DateTime>(name: "Date_Time", type: "datetime", nullable: false),
                    InOut = table.Column<string>(name: "In_Out", type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    EMPID = table.Column<decimal>(name: "EMP_ID", type: "numeric(19,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TIMEKEEP__3421CD0F46BA6804", x => x.TimekeeperId);
                    table.ForeignKey(
                        name: "FK744D9BFF6106A42",
                        column: x => x.EMPID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EMP_ID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__DEPARTME__512A302D197A5DD5",
                table: "DEPARTMENT",
                column: "DEPT_NO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_DEPT_ID",
                table: "EMPLOYEE",
                column: "DEPT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_MNG_ID",
                table: "EMPLOYEE",
                column: "MNG_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__EMPLOYEE__16EB127C4EA884EA",
                table: "EMPLOYEE",
                column: "EMP_NO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TIMEKEEPER_EMP_ID",
                table: "TIMEKEEPER",
                column: "EMP_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SALARY_GRADE");

            migrationBuilder.DropTable(
                name: "TIMEKEEPER");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            migrationBuilder.DropTable(
                name: "DEPARTMENT");
        }
    }
}
