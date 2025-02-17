using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace deliflow_backend.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Deliveries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Deliveries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Deliveries");
        }
    }
}
