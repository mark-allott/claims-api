using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Company_Claims_FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Identity",
                table: "Claims",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Claims",
                table: "Claims",
                column: "Identity");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_CompanyId",
                table: "Claims",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Company_CompanyId",
                table: "Claims",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Identity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Company_CompanyId",
                table: "Claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Claims",
                table: "Claims");

            migrationBuilder.DropIndex(
                name: "IX_Claims_CompanyId",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "Identity",
                table: "Claims");
        }
    }
}
