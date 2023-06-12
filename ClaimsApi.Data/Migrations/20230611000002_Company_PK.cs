using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Company_PK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Identity",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identity",
                table: "Company");
        }
    }
}
