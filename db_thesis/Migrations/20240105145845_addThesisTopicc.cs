using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace db_thesis.Migrations
{
    /// <inheritdoc />
    public partial class addThesisTopicc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThesisTopic",
                table: "Thesisses",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThesisTopic",
                table: "Thesisses");
        }
    }
}
