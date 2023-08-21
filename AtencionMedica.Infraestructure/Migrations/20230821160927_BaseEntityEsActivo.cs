using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtencionMedica.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class BaseEntityEsActivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsActivo",
                table: "PacienteDiabetico",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EsActivo",
                table: "PacienteAdultoMayor",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsActivo",
                table: "PacienteDiabetico");

            migrationBuilder.DropColumn(
                name: "EsActivo",
                table: "PacienteAdultoMayor");
        }
    }
}
