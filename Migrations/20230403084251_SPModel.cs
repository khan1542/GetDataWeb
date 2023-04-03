using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetDataWeb.Migrations
{
    /// <inheritdoc />
    public partial class SPModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SPModels",
                columns: table => new
                {
                    Descr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sDp1 = table.Column<double>(type: "float", nullable: false),
                    sDp2 = table.Column<double>(type: "float", nullable: false),
                    sDp4 = table.Column<double>(type: "float", nullable: false),
                    sDp6 = table.Column<double>(type: "float", nullable: false),
                    sDp7 = table.Column<double>(type: "float", nullable: false),
                    sDp8 = table.Column<double>(type: "float", nullable: false),
                    sDp9 = table.Column<double>(type: "float", nullable: false),
                    sDp10 = table.Column<double>(type: "float", nullable: false),
                    sDp255 = table.Column<double>(type: "float", nullable: false),
                    sDpBegYear = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPModels");
        }
    }
}
