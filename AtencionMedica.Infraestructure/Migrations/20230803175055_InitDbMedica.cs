using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtencionMedica.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDbMedica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complicacion",
                columns: table => new
                {
                    IdComplicacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreComplicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complicacion", x => x.IdComplicacion);
                });

            migrationBuilder.CreateTable(
                name: "Comuna",
                columns: table => new
                {
                    IdComuna = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreComuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiglaRegion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comuna", x => x.IdComuna);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    IdEspecialidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEspecialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.IdEspecialidad);
                });

            migrationBuilder.CreateTable(
                name: "EstadoAgendaMedico",
                columns: table => new
                {
                    IdEstadoAgendaMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstadoAgendaMedico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAgendaMedico", x => x.IdEstadoAgendaMedico);
                });

            migrationBuilder.CreateTable(
                name: "EstadoFichaClinica",
                columns: table => new
                {
                    IdEstadoFichaClinica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstadoFichaClinica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoFichaClinica", x => x.IdEstadoFichaClinica);
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    IdMedicamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMedicamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.IdMedicamento);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    IdMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut = table.Column<int>(type: "int", nullable: false),
                    Dv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.IdMedico);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut = table.Column<int>(type: "int", nullable: false),
                    Dv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Patologia",
                columns: table => new
                {
                    IdPatologia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePatologia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patologia", x => x.IdPatologia);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    IdPersonal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut = table.Column<int>(type: "int", nullable: false),
                    Dv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.IdPersonal);
                });

            migrationBuilder.CreateTable(
                name: "LugarAtencion",
                columns: table => new
                {
                    IdLugarAtencion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdComuna = table.Column<int>(type: "int", nullable: false),
                    NombreLugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorarioAtencion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugarAtencion", x => x.IdLugarAtencion);
                    table.ForeignKey(
                        name: "FK_LugarAtencion_Comuna",
                        column: x => x.IdComuna,
                        principalTable: "Comuna",
                        principalColumn: "IdComuna");
                });

            migrationBuilder.CreateTable(
                name: "AgendaMedico",
                columns: table => new
                {
                    IdAgendaMedico = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdEstadoAgendaMedico = table.Column<int>(type: "int", nullable: false),
                    FecInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraInicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraFin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaMedico", x => x.IdAgendaMedico);
                    table.ForeignKey(
                        name: "FK_AgendaMedico_EstadoAgendaMedico",
                        column: x => x.IdEstadoAgendaMedico,
                        principalTable: "EstadoAgendaMedico",
                        principalColumn: "IdEstadoAgendaMedico");
                    table.ForeignKey(
                        name: "FK_AgendaMedico_Medico",
                        column: x => x.IdMedico,
                        principalTable: "Medico",
                        principalColumn: "IdMedico");
                });

            migrationBuilder.CreateTable(
                name: "EspecialidadMedico",
                columns: table => new
                {
                    IdEspecialidadMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEspecialidad = table.Column<int>(type: "int", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    CasaEstudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaObtencionEspecialidad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadMedico", x => x.IdEspecialidadMedico);
                    table.ForeignKey(
                        name: "FK_EspecialidadMedico_Especialidad",
                        column: x => x.IdEspecialidad,
                        principalTable: "Especialidad",
                        principalColumn: "IdEspecialidad");
                    table.ForeignKey(
                        name: "FK_EspecialidadMedico_Medico",
                        column: x => x.IdMedico,
                        principalTable: "Medico",
                        principalColumn: "IdMedico");
                });

            migrationBuilder.CreateTable(
                name: "ComplicacionPaciente",
                columns: table => new
                {
                    IdComplicacionPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdComplicacion = table.Column<int>(type: "int", nullable: false),
                    FecComplicacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplicacionPaciente", x => x.IdComplicacionPaciente);
                    table.ForeignKey(
                        name: "FK_ComplicacionPaciente_Complicacion",
                        column: x => x.IdComplicacion,
                        principalTable: "Complicacion",
                        principalColumn: "IdComplicacion");
                    table.ForeignKey(
                        name: "FK_ComplicacionPaciente_Paciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateTable(
                name: "HistorialClinico",
                columns: table => new
                {
                    IdHistorialClinico = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    FechaHistorial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialClinico", x => x.IdHistorialClinico);
                    table.ForeignKey(
                        name: "FK_HistorialClinico_Paciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateTable(
                name: "PacienteAdultoMayor",
                columns: table => new
                {
                    IdPacienteAdultoMayor = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    AutoValente = table.Column<bool>(type: "bit", nullable: false),
                    Dependencia = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteAdultoMayor", x => x.IdPacienteAdultoMayor);
                    table.ForeignKey(
                        name: "FK_PacienteAdultoMayor_Paciente",
                        column: x => x.IdPacienteAdultoMayor,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateTable(
                name: "PacienteDiabetico",
                columns: table => new
                {
                    IdPacienteDiabetico = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    FecEvaluacionDiabetes = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Neuropatia = table.Column<bool>(type: "bit", nullable: false),
                    FecNeuropatia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amputacion = table.Column<bool>(type: "bit", nullable: false),
                    FecAmputacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Retinopatia = table.Column<bool>(type: "bit", nullable: false),
                    FecRetinopatia = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteDiabetico", x => x.IdPacienteDiabetico);
                    table.ForeignKey(
                        name: "FK_PacienteDiabetico_Paciente",
                        column: x => x.IdPacienteDiabetico,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateTable(
                name: "PatologiaPaciente",
                columns: table => new
                {
                    IdPatologiaPaciente = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPatologia = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    FecComplicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatologiaPaciente", x => x.IdPatologiaPaciente);
                    table.ForeignKey(
                        name: "FK_PatologiaPaciente_Paciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente");
                    table.ForeignKey(
                        name: "FK_PatologiaPaciente_Patologia",
                        column: x => x.IdPatologia,
                        principalTable: "Patologia",
                        principalColumn: "IdPatologia");
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    IdModulo = table.Column<int>(type: "int", nullable: false),
                    IdLugarAtencion = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.IdModulo);
                    table.ForeignKey(
                        name: "FK_Modulo_LugarAtencion",
                        column: x => x.IdModulo,
                        principalTable: "LugarAtencion",
                        principalColumn: "IdLugarAtencion");
                });

            migrationBuilder.CreateTable(
                name: "RecetaMedica",
                columns: table => new
                {
                    IdRecetaMedica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHistorialClinico = table.Column<long>(type: "bigint", nullable: false),
                    IdMedicamento = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Instrucciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FecInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaMedica", x => x.IdRecetaMedica);
                    table.ForeignKey(
                        name: "FK_RecetaMedica_HistorialClinico",
                        column: x => x.IdHistorialClinico,
                        principalTable: "HistorialClinico",
                        principalColumn: "IdHistorialClinico");
                    table.ForeignKey(
                        name: "FK_RecetaMedica_Medicamento",
                        column: x => x.IdMedicamento,
                        principalTable: "Medicamento",
                        principalColumn: "IdMedicamento");
                });

            migrationBuilder.CreateTable(
                name: "FichaClinica",
                columns: table => new
                {
                    IdFichaClinica = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdPersonal = table.Column<int>(type: "int", nullable: true),
                    IdEstadoFichaClinica = table.Column<int>(type: "int", nullable: false),
                    IdModulo = table.Column<int>(type: "int", nullable: false),
                    FechaAtencion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaClinica", x => x.IdFichaClinica);
                    table.ForeignKey(
                        name: "FK_FichaClinica_EstadoFichaClinica",
                        column: x => x.IdEstadoFichaClinica,
                        principalTable: "EstadoFichaClinica",
                        principalColumn: "IdEstadoFichaClinica");
                    table.ForeignKey(
                        name: "FK_FichaClinica_Medico",
                        column: x => x.IdMedico,
                        principalTable: "Medico",
                        principalColumn: "IdMedico");
                    table.ForeignKey(
                        name: "FK_FichaClinica_Modulo",
                        column: x => x.IdModulo,
                        principalTable: "Modulo",
                        principalColumn: "IdModulo");
                    table.ForeignKey(
                        name: "FK_FichaClinica_Paciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente");
                    table.ForeignKey(
                        name: "FK_FichaClinica_Personal",
                        column: x => x.IdPersonal,
                        principalTable: "Personal",
                        principalColumn: "IdPersonal");
                });

            migrationBuilder.CreateTable(
                name: "FichaClinicaDetalle",
                columns: table => new
                {
                    IdFichaClinicaDetalle = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFichaClinica = table.Column<long>(type: "bigint", nullable: false),
                    AgudezaVisual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresionIntraocular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FondoDeOjo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaClinicaDetalle", x => x.IdFichaClinicaDetalle);
                    table.ForeignKey(
                        name: "FK_FichaClinicaDetalle_FichaClinica",
                        column: x => x.IdFichaClinica,
                        principalTable: "FichaClinica",
                        principalColumn: "IdFichaClinica");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaMedico_IdEstadoAgendaMedico",
                table: "AgendaMedico",
                column: "IdEstadoAgendaMedico");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaMedico_IdMedico",
                table: "AgendaMedico",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_ComplicacionPaciente_IdComplicacion",
                table: "ComplicacionPaciente",
                column: "IdComplicacion");

            migrationBuilder.CreateIndex(
                name: "IX_ComplicacionPaciente_IdPaciente",
                table: "ComplicacionPaciente",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadMedico_IdEspecialidad",
                table: "EspecialidadMedico",
                column: "IdEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadMedico_IdMedico",
                table: "EspecialidadMedico",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_FichaClinica_IdEstadoFichaClinica",
                table: "FichaClinica",
                column: "IdEstadoFichaClinica");

            migrationBuilder.CreateIndex(
                name: "IX_FichaClinica_IdMedico",
                table: "FichaClinica",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_FichaClinica_IdModulo",
                table: "FichaClinica",
                column: "IdModulo");

            migrationBuilder.CreateIndex(
                name: "IX_FichaClinica_IdPaciente",
                table: "FichaClinica",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_FichaClinica_IdPersonal",
                table: "FichaClinica",
                column: "IdPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_FichaClinicaDetalle_IdFichaClinica",
                table: "FichaClinicaDetalle",
                column: "IdFichaClinica");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialClinico_IdPaciente",
                table: "HistorialClinico",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_LugarAtencion_IdComuna",
                table: "LugarAtencion",
                column: "IdComuna");

            migrationBuilder.CreateIndex(
                name: "IX_PatologiaPaciente_IdPaciente",
                table: "PatologiaPaciente",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_PatologiaPaciente_IdPatologia",
                table: "PatologiaPaciente",
                column: "IdPatologia");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaMedica_IdHistorialClinico",
                table: "RecetaMedica",
                column: "IdHistorialClinico");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaMedica_IdMedicamento",
                table: "RecetaMedica",
                column: "IdMedicamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaMedico");

            migrationBuilder.DropTable(
                name: "ComplicacionPaciente");

            migrationBuilder.DropTable(
                name: "EspecialidadMedico");

            migrationBuilder.DropTable(
                name: "FichaClinicaDetalle");

            migrationBuilder.DropTable(
                name: "PacienteAdultoMayor");

            migrationBuilder.DropTable(
                name: "PacienteDiabetico");

            migrationBuilder.DropTable(
                name: "PatologiaPaciente");

            migrationBuilder.DropTable(
                name: "RecetaMedica");

            migrationBuilder.DropTable(
                name: "EstadoAgendaMedico");

            migrationBuilder.DropTable(
                name: "Complicacion");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "FichaClinica");

            migrationBuilder.DropTable(
                name: "Patologia");

            migrationBuilder.DropTable(
                name: "HistorialClinico");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "EstadoFichaClinica");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Modulo");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "LugarAtencion");

            migrationBuilder.DropTable(
                name: "Comuna");
        }
    }
}
