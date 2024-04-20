using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psicologiaa.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "datosPersonales",
                columns: table => new
                {
                    IdDatos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datosPersonales", x => x.IdDatos);
                });

            migrationBuilder.CreateTable(
                name: "evaluacion",
                columns: table => new
                {
                    IdEvaluacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    TipoEvaluacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resultados = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evaluacion", x => x.IdEvaluacion);
                });

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDatos = table.Column<int>(type: "int", nullable: false),
                    DatosPersonalesIdDatos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paciente", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "FK_paciente_datosPersonales_DatosPersonalesIdDatos",
                        column: x => x.DatosPersonalesIdDatos,
                        principalTable: "datosPersonales",
                        principalColumn: "IdDatos");
                });

            migrationBuilder.CreateTable(
                name: "terapeuta",
                columns: table => new
                {
                    IdTerapeuta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDatos = table.Column<int>(type: "int", nullable: false),
                    DatosPersonalesIdDatos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_terapeuta", x => x.IdTerapeuta);
                    table.ForeignKey(
                        name: "FK_terapeuta_datosPersonales_DatosPersonalesIdDatos",
                        column: x => x.DatosPersonalesIdDatos,
                        principalTable: "datosPersonales",
                        principalColumn: "IdDatos");
                });

            migrationBuilder.CreateTable(
                name: "sesion",
                columns: table => new
                {
                    IdSesion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    PacienteIdPaciente = table.Column<int>(type: "int", nullable: true),
                    IdEvaluacion = table.Column<int>(type: "int", nullable: false),
                    EvaluacionIdEvaluacion = table.Column<int>(type: "int", nullable: true),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    TiempoSesion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sesion", x => x.IdSesion);
                    table.ForeignKey(
                        name: "FK_sesion_evaluacion_EvaluacionIdEvaluacion",
                        column: x => x.EvaluacionIdEvaluacion,
                        principalTable: "evaluacion",
                        principalColumn: "IdEvaluacion");
                    table.ForeignKey(
                        name: "FK_sesion_paciente_PacienteIdPaciente",
                        column: x => x.PacienteIdPaciente,
                        principalTable: "paciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateIndex(
                name: "IX_paciente_DatosPersonalesIdDatos",
                table: "paciente",
                column: "DatosPersonalesIdDatos");

            migrationBuilder.CreateIndex(
                name: "IX_sesion_EvaluacionIdEvaluacion",
                table: "sesion",
                column: "EvaluacionIdEvaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_sesion_PacienteIdPaciente",
                table: "sesion",
                column: "PacienteIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_terapeuta_DatosPersonalesIdDatos",
                table: "terapeuta",
                column: "DatosPersonalesIdDatos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sesion");

            migrationBuilder.DropTable(
                name: "terapeuta");

            migrationBuilder.DropTable(
                name: "evaluacion");

            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "datosPersonales");
        }
    }
}
