using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class UCR_Index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Claims_UCR",
                table: "Claims",
                column: "UCR",
                unique: true,
                filter: "[UCR] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Claims_UCR",
                table: "Claims");
        }
    }
}
