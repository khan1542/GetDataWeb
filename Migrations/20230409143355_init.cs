using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetDataWeb.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SPDests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sDP1 = table.Column<double>(type: "float", nullable: true),
                    sDP2 = table.Column<double>(type: "float", nullable: true),
                    sDP4 = table.Column<double>(type: "float", nullable: true),
                    sDP6 = table.Column<double>(type: "float", nullable: true),
                    sDP7 = table.Column<double>(type: "float", nullable: true),
                    sDP8 = table.Column<double>(type: "float", nullable: true),
                    sDP9 = table.Column<double>(type: "float", nullable: true),
                    sDP10 = table.Column<double>(type: "float", nullable: true),
                    sDP255 = table.Column<double>(type: "float", nullable: true),
                    sDPBegYear = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPDests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPDests");
        }
    }
}
