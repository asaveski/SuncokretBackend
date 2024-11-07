using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuncokretBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddressCityAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Address");
        }
    }
}
