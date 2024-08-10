using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StithAutoGroup.Migrations
{
    /// <inheritdoc />
    public partial class IdentitySomeClaimsRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AutoGroupEmployee",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AutoGroupUserLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CellPhoneNumber1",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltEmail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AutoGroupEmployee",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AutoGroupUserLink",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CellPhoneNumber1",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
