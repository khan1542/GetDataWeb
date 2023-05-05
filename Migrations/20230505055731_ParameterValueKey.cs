using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetDataWeb.Migrations
{
    /// <inheritdoc />
    public partial class ParameterValueKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ParameterValues",
                table: "ParameterValues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParameterValues",
                table: "ParameterValues",
                columns: new[] { "PechId", "ParameterId", "DtFirstDay" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ParameterValues",
                table: "ParameterValues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParameterValues",
                table: "ParameterValues",
                column: "DtFirstDay");
        }
    }
}
