using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetDataWeb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    ID_Parameter = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.ID_Parameter);
                });

            migrationBuilder.CreateTable(
                name: "ParameterValues",
                columns: table => new
                {
                    dtFistDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Parameter = table.Column<int>(type: "int", nullable: false),
                    ID_Pech = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterValues", x => x.dtFistDay);
                    table.ForeignKey(
                        name: "FK_ParameterValues_Parameters_ID_Parameter",
                        column: x => x.ID_Parameter,
                        principalTable: "Parameters",
                        principalColumn: "ID_Parameter",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParameterValues_ID_Parameter",
                table: "ParameterValues",
                column: "ID_Parameter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParameterValues");

            migrationBuilder.DropTable(
                name: "Parameters");
        }
    }
}
