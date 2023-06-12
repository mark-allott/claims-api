using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    UCR = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    ClaimDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    AssuredName = table.Column<string>(name: "Assured Name", type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    IncurredLoss = table.Column<decimal>(name: "Incurred Loss", type: "DECIMAL(15,2)", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ClaimType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    Address1 = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Address3 = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    PostCode = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    InsuranceEndDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "ClaimType");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
