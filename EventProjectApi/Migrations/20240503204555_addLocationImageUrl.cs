using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventProjectApi.Migrations
{
    /// <inheritdoc />
    public partial class addLocationImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationImageUrl",
                table: "Events");
        }
    }
}
