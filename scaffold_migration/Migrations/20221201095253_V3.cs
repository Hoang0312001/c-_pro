using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scaffoldmigration.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Info_EMP",
                table: "EMPLOYEE",
                type: "nvarchar(500)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info_EMP",
                table: "EMPLOYEE");
        }
    }
}
