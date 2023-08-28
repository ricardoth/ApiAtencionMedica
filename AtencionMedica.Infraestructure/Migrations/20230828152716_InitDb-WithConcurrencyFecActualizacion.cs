using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AtencionMedica.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDbWithConcurrencyFecActualizacion : Migration
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
                    NombreComplicacion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    NombreComuna = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    SiglaRegion = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    NombreEspecialidad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    NombreEstadoAgendaMedico = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    NombreEstadoFichaClinica = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    NombreMedicamento = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Rut = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Dv = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Nombres = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Correo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Rut = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Dv = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Nombres = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Correo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    EstadoCivil = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Sexo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true)
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
                    NombrePatologia = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Rut = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Dv = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Nombres = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Correo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    NombreLugar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Fono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    HorarioAtencion = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    IdAgendaMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdEstadoAgendaMedico = table.Column<int>(type: "int", nullable: false),
                    FecInicio = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    FecFin = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    HoraInicio = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    HoraFin = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true)
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
                    CasaEstudio = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    FechaObtencionEspecialidad = table.Column<DateTime>(type: "datetime", unicode: false, nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    FecComplicacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    IdHistorialClinico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    FechaHistorial = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    Diagnostico = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Nota = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true)
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
                    IdPacienteAdultoMayor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    AutoValente = table.Column<bool>(type: "bit", nullable: false),
                    Dependencia = table.Column<bool>(type: "bit", nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteAdultoMayor", x => x.IdPacienteAdultoMayor);
                    table.ForeignKey(
                        name: "FK_PacienteAdultoMayor_Paciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateTable(
                name: "PacienteDiabetico",
                columns: table => new
                {
                    IdPacienteDiabetico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    FecEvaluacionDiabetes = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    Neuropatia = table.Column<bool>(type: "bit", nullable: false),
                    FecNeuropatia = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    Amputacion = table.Column<bool>(type: "bit", nullable: false),
                    FecAmputacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    Retinopatia = table.Column<bool>(type: "bit", nullable: false),
                    FecRetinopatia = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteDiabetico", x => x.IdPacienteDiabetico);
                    table.ForeignKey(
                        name: "FK_PacienteDiabetico_Paciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateTable(
                name: "PatologiaPaciente",
                columns: table => new
                {
                    IdPatologiaPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPatologia = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    FecComplicacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true)
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
                    IdModulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLugarAtencion = table.Column<int>(type: "int", nullable: false),
                    NombreModulo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.IdModulo);
                    table.ForeignKey(
                        name: "FK_Modulo_LugarAtencion",
                        column: x => x.IdLugarAtencion,
                        principalTable: "LugarAtencion",
                        principalColumn: "IdLugarAtencion");
                });

            migrationBuilder.CreateTable(
                name: "RecetaMedica",
                columns: table => new
                {
                    IdRecetaMedica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHistorialClinico = table.Column<int>(type: "int", nullable: false),
                    IdMedicamento = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Instrucciones = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Observacion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    FecInicio = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    FecFin = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true)
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
                    IdFichaClinica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdPersonal = table.Column<int>(type: "int", nullable: true),
                    IdEstadoFichaClinica = table.Column<int>(type: "int", nullable: false),
                    IdModulo = table.Column<int>(type: "int", nullable: false),
                    FechaAtencion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true)
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
                    IdFichaClinicaDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFichaClinica = table.Column<int>(type: "int", nullable: false),
                    AgudezaVisual = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PresionIntraocular = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FondoDeOjo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Observacion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FecCreacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true),
                    FecActualizacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true)
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

            migrationBuilder.InsertData(
                table: "Comuna",
                columns: new[] { "IdComuna", "EsActivo", "FecActualizacion", "FecCreacion", "NombreComuna", "Region", "SiglaRegion" },
                values: new object[,]
                {
                    { 1, true, null, null, "Arica", "Región de Tarapacá", "I" },
                    { 2, true, null, null, "Camarones", "Región de Tarapacá", "I" },
                    { 3, true, null, null, "Alto Hospicio", "Región de Antofagasta", "II" },
                    { 4, true, null, null, "Iquique", "Región de Antofagasta", "II" },
                    { 5, true, null, null, "Camiña", "Región de Antofagasta", "II" },
                    { 6, true, null, null, "Colchane", "Región de Antofagasta", "II" },
                    { 7, true, null, null, "Huara", "Región de Antofagasta", "II" },
                    { 8, true, null, null, "Pica", "Región de Antofagasta", "II" },
                    { 9, true, null, null, "Pozo Almonte", "Región de Antofagasta", "II" },
                    { 10, true, null, null, "Caldera", "Región de Atacama", "III" },
                    { 11, true, null, null, "Chanaral", "Región de Atacama", "III" },
                    { 12, true, null, null, "Copiapó", "Región de Atacama", "III" },
                    { 13, true, null, null, "Diego de Almagro", "Región de Atacama", "III" },
                    { 14, true, null, null, "Freirina", "Región de Atacama", "III" },
                    { 15, true, null, null, "Huasco", "Región de Atacama", "III" },
                    { 16, true, null, null, "Tierra Amarilla", "Región de Atacama", "III" },
                    { 17, true, null, null, "Vallenar", "Región de Atacama", "III" },
                    { 18, true, null, null, "Andacollo", "Región de Coquimbo", "IV" },
                    { 19, true, null, null, "Canela", "Región de Coquimbo", "IV" },
                    { 20, true, null, null, "Combarbalá", "Región de Coquimbo", "IV" },
                    { 21, true, null, null, "Coquimbo", "Región de Coquimbo", "IV" },
                    { 22, true, null, null, "Illapel", "Región de Coquimbo", "IV" },
                    { 23, true, null, null, "La Higuera", "Región de Coquimbo", "IV" },
                    { 24, true, null, null, "La Serena", "Región de Coquimbo", "IV" },
                    { 25, true, null, null, "Los Vilos", "Región de Coquimbo", "IV" },
                    { 26, true, null, null, "Monte Patria", "Región de Coquimbo", "IV" },
                    { 27, true, null, null, "Ovalle", "Región de Coquimbo", "IV" },
                    { 28, true, null, null, "Paihuano", "Región de Coquimbo", "IV" },
                    { 29, true, null, null, "Punitaqui", "Región de Coquimbo", "IV" },
                    { 30, true, null, null, "Río Hurtado", "Región de Coquimbo", "IV" },
                    { 31, true, null, null, "Salamanca", "Región de Coquimbo", "IV" },
                    { 32, true, null, null, "Vicuña", "Región de Coquimbo", "IV" },
                    { 33, true, null, null, "Algarrobo", "Región de Valparaíso", "V" },
                    { 34, true, null, null, "Cabildo", "Región de Valparaíso", "V" },
                    { 35, true, null, null, "Calera", "Región de Valparaíso", "V" },
                    { 36, true, null, null, "Calle Larga", "Región de Valparaíso", "V" },
                    { 37, true, null, null, "Cartagena", "Región de Valparaíso", "V" },
                    { 38, true, null, null, "Casablanca", "Región de Valparaíso", "V" },
                    { 39, true, null, null, "Catemu", "Región de Valparaíso", "V" },
                    { 40, true, null, null, "Concón", "Región de Valparaíso", "V" },
                    { 41, true, null, null, "El Quisco", "Región de Valparaíso", "V" },
                    { 42, true, null, null, "El Tabo", "Región de Valparaíso", "V" },
                    { 43, true, null, null, "Hijuelas", "Región de Valparaíso", "V" },
                    { 44, true, null, null, "Isla de Pascua", "Región de Valparaíso", "V" },
                    { 45, true, null, null, "Juan Fernández", "Región de Valparaíso", "V" },
                    { 46, true, null, null, "La Cruz", "Región de Valparaíso", "V" },
                    { 47, true, null, null, "La Ligua", "Región de Valparaíso", "V" },
                    { 48, true, null, null, "Limache", "Región de Valparaíso", "V" },
                    { 49, true, null, null, "Llaillay", "Región de Valparaíso", "V" },
                    { 50, true, null, null, "Los Andes", "Región de Valparaíso", "V" },
                    { 51, true, null, null, "Nogales", "Región de Valparaíso", "V" },
                    { 52, true, null, null, "Olmué", "Región de Valparaíso", "V" },
                    { 53, true, null, null, "Panquehue", "Región de Valparaíso", "V" },
                    { 54, true, null, null, "Papudo", "Región de Valparaíso", "V" },
                    { 55, true, null, null, "Petorca", "Región de Valparaíso", "V" },
                    { 56, true, null, null, "Puchuncaví", "Región de Valparaíso", "V" },
                    { 57, true, null, null, "Putaendo", "Región de Valparaíso", "V" },
                    { 58, true, null, null, "Quillota", "Región de Valparaíso", "V" },
                    { 59, true, null, null, "Quilpué", "Región de Valparaíso", "V" },
                    { 60, true, null, null, "Quintero", "Región de Valparaíso", "V" },
                    { 61, true, null, null, "Rinconada", "Región de Valparaíso", "V" },
                    { 62, true, null, null, "San Antonio", "Región de Valparaíso", "V" },
                    { 63, true, null, null, "San Esteban", "Región de Valparaíso", "V" },
                    { 64, true, null, null, "San Felipe", "Región de Valparaíso", "V" },
                    { 65, true, null, null, "Santa María", "Región de Valparaíso", "V" },
                    { 66, true, null, null, "Santo Domingo", "Región de Valparaíso", "V" },
                    { 67, true, null, null, "Valparaíso", "Región de Valparaíso", "V" },
                    { 68, true, null, null, "Villa Alemana", "Región de Valparaíso", "V" },
                    { 69, true, null, null, "Viña del Mar", "Región de Valparaíso", "V" },
                    { 70, true, null, null, "Zapallar", "Región de Valparaíso", "V" },
                    { 71, true, null, null, "Alhué", "Región Metropolitana de Santiago", "RM" },
                    { 72, true, null, null, "Buin", "Región Metropolitana de Santiago", "RM" },
                    { 73, true, null, null, "Calera de Tango", "Región Metropolitana de Santiago", "RM" },
                    { 74, true, null, null, "Cerrillos", "Región Metropolitana de Santiago", "RM" },
                    { 75, true, null, null, "Cerro Navia", "Región Metropolitana de Santiago", "RM" },
                    { 76, true, null, null, "Colina", "Región Metropolitana de Santiago", "RM" },
                    { 77, true, null, null, "Conchalí", "Región Metropolitana de Santiago", "RM" },
                    { 78, true, null, null, "Curacaví", "Región Metropolitana de Santiago", "RM" },
                    { 79, true, null, null, "El Bosque", "Región Metropolitana de Santiago", "RM" },
                    { 80, true, null, null, "El Monte", "Región Metropolitana de Santiago", "RM" },
                    { 81, true, null, null, "Estación Central", "Región Metropolitana de Santiago", "RM" },
                    { 82, true, null, null, "Huechuraba", "Región Metropolitana de Santiago", "RM" },
                    { 83, true, null, null, "Independencia", "Región Metropolitana de Santiago", "RM" },
                    { 84, true, null, null, "Isla de Maipo", "Región Metropolitana de Santiago", "RM" },
                    { 85, true, null, null, "La Cisterna", "Región Metropolitana de Santiago", "RM" },
                    { 86, true, null, null, "La Florida", "Región Metropolitana de Santiago", "RM" },
                    { 87, true, null, null, "La Granja", "Región Metropolitana de Santiago", "RM" },
                    { 88, true, null, null, "La Pintana", "Región Metropolitana de Santiago", "RM" },
                    { 89, true, null, null, "La Reina", "Región Metropolitana de Santiago", "RM" },
                    { 90, true, null, null, "Lampa", "Región Metropolitana de Santiago", "RM" },
                    { 91, true, null, null, "Las Condes", "Región Metropolitana de Santiago", "RM" },
                    { 92, true, null, null, "Lo Barnechea", "Región Metropolitana de Santiago", "RM" },
                    { 93, true, null, null, "Lo Espejo", "Región Metropolitana de Santiago", "RM" },
                    { 94, true, null, null, "Lo Prado", "Región Metropolitana de Santiago", "RM" },
                    { 95, true, null, null, "Macul", "Región Metropolitana de Santiago", "RM" },
                    { 96, true, null, null, "Maipú", "Región Metropolitana de Santiago", "RM" },
                    { 97, true, null, null, "María Pinto", "Región Metropolitana de Santiago", "RM" },
                    { 98, true, null, null, "Melipilla", "Región Metropolitana de Santiago", "RM" },
                    { 99, true, null, null, "Ñuñoa", "Región Metropolitana de Santiago", "RM" },
                    { 100, true, null, null, "Padre Hurtado", "Región Metropolitana de Santiago", "RM" },
                    { 101, true, null, null, "Paine", "Región Metropolitana de Santiago", "RM" },
                    { 102, true, null, null, "Pedro Aguirre Cerda", "Región Metropolitana de Santiago", "RM" },
                    { 103, true, null, null, "Peñaflor", "Región Metropolitana de Santiago", "RM" },
                    { 104, true, null, null, "Peñalolén", "Región Metropolitana de Santiago", "RM" },
                    { 105, true, null, null, "Pirque", "Región Metropolitana de Santiago", "RM" },
                    { 106, true, null, null, "Providencia", "Región Metropolitana de Santiago", "RM" },
                    { 107, true, null, null, "Pudahuel", "Región Metropolitana de Santiago", "RM" },
                    { 108, true, null, null, "Puente Alto", "Región Metropolitana de Santiago", "RM" },
                    { 109, true, null, null, "Quilicura", "Región Metropolitana de Santiago", "RM" },
                    { 110, true, null, null, "Quinta Normal", "Región Metropolitana de Santiago", "RM" },
                    { 111, true, null, null, "Recoleta", "Región Metropolitana de Santiago", "RM" },
                    { 112, true, null, null, "Renca", "Región Metropolitana de Santiago", "RM" },
                    { 113, true, null, null, "San Bernardo", "Región Metropolitana de Santiago", "RM" },
                    { 114, true, null, null, "San Joaquín", "Región Metropolitana de Santiago", "RM" },
                    { 115, true, null, null, "San José de Maipo", "Región Metropolitana de Santiago", "RM" },
                    { 116, true, null, null, "San Miguel", "Región Metropolitana de Santiago", "RM" },
                    { 117, true, null, null, "San Pedro", "Región Metropolitana de Santiago", "RM" },
                    { 118, true, null, null, "San Ramón", "Región Metropolitana de Santiago", "RM" },
                    { 119, true, null, null, "Santiago", "Región Metropolitana de Santiago", "RM" },
                    { 120, true, null, null, "Talagante", "Región Metropolitana de Santiago", "RM" },
                    { 121, true, null, null, "Tiltil", "Región Metropolitana de Santiago", "RM" },
                    { 122, true, null, null, "Vitacura", "Región Metropolitana de Santiago", "RM" },
                    { 123, true, null, null, "Cachapoal", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 124, true, null, null, "Cardenal Caro", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 125, true, null, null, "Chépica", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 126, true, null, null, "Chimbarongo", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 127, true, null, null, "Codegua", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 128, true, null, null, "Coinco", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 129, true, null, null, "Coltauco", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 130, true, null, null, "Doñihue", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 131, true, null, null, "Graneros", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 132, true, null, null, "La Estrella", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 133, true, null, null, "Las Cabras", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 134, true, null, null, "Litueche", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 135, true, null, null, "Lolol", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 136, true, null, null, "Machalí", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 137, true, null, null, "Malloa", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 138, true, null, null, "Marchihue", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 139, true, null, null, "Nancagua", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 140, true, null, null, "Navidad", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 141, true, null, null, "Olivar", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 142, true, null, null, "Palmilla", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 143, true, null, null, "Paredones", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 144, true, null, null, "Peralillo", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 145, true, null, null, "Peumo", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 146, true, null, null, "Pichidegua", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 147, true, null, null, "Pichilemu", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 148, true, null, null, "Placilla", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 149, true, null, null, "Pumanque", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 150, true, null, null, "Quinta de Tilcoco", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 151, true, null, null, "Rancagua", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 152, true, null, null, "Rengo", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 153, true, null, null, "Requínoa", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 154, true, null, null, "San Fernando", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 155, true, null, null, "San Vicente de Tagua Tagua", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 156, true, null, null, "Santa Cruz", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 157, true, null, null, "Cauquenes", "Región del Maule", "VII" },
                    { 158, true, null, null, "Chanco", "Región del Maule", "VII" },
                    { 159, true, null, null, "Colbún", "Región del Maule", "VII" },
                    { 160, true, null, null, "Constitución", "Región del Maule", "VII" },
                    { 161, true, null, null, "Curepto", "Región del Maule", "VII" },
                    { 162, true, null, null, "Curicó", "Región del Maule", "VII" },
                    { 163, true, null, null, "Empedrado", "Región del Maule", "VII" },
                    { 164, true, null, null, "Hualañé", "Región del Maule", "VII" },
                    { 165, true, null, null, "Licantén", "Región del Maule", "VII" },
                    { 166, true, null, null, "Linares", "Región del Maule", "VII" },
                    { 167, true, null, null, "Longaví", "Región del Maule", "VII" },
                    { 168, true, null, null, "Maule", "Región del Maule", "VII" },
                    { 169, true, null, null, "Molina", "Región del Maule", "VII" },
                    { 170, true, null, null, "Parral", "Región del Maule", "VII" },
                    { 171, true, null, null, "Pelarco", "Región del Maule", "VII" },
                    { 172, true, null, null, "Pelluhue", "Región del Maule", "VII" },
                    { 173, true, null, null, "Pencahue", "Región del Maule", "VII" },
                    { 174, true, null, null, "Rauco", "Región del Maule", "VII" },
                    { 175, true, null, null, "Retiro", "Región del Maule", "VII" },
                    { 176, true, null, null, "Romeral", "Región del Maule", "VII" },
                    { 177, true, null, null, "Sagrada Familia", "Región del Maule", "VII" },
                    { 178, true, null, null, "San Clemente", "Región del Maule", "VII" },
                    { 179, true, null, null, "San Javier", "Región del Maule", "VII" },
                    { 180, true, null, null, "San Rafael", "Región del Maule", "VII" },
                    { 181, true, null, null, "Santa Cruz", "Región del Maule", "VII" },
                    { 182, true, null, null, "Talca", "Región del Maule", "VII" },
                    { 183, true, null, null, "Teno", "Región del Maule", "VII" },
                    { 184, true, null, null, "Vichuquén", "Región del Maule", "VII" },
                    { 185, true, null, null, "Villa Alegre", "Región del Maule", "VII" },
                    { 186, true, null, null, "Yerbas Buenas", "Región del Maule", "VII" },
                    { 187, true, null, null, "Alto Biobío", "Región del Biobío", "VIII" },
                    { 188, true, null, null, "Antuco", "Región del Biobío", "VIII" },
                    { 189, true, null, null, "Arauco", "Región del Biobío", "VIII" },
                    { 190, true, null, null, "Bulnes", "Región del Biobío", "VIII" },
                    { 191, true, null, null, "Cabrero", "Región del Biobío", "VIII" },
                    { 192, true, null, null, "Cañete", "Región del Biobío", "VIII" },
                    { 193, true, null, null, "Chiguayante", "Región del Biobío", "VIII" },
                    { 194, true, null, null, "Chillán", "Región del Biobío", "VIII" },
                    { 195, true, null, null, "Chillán Viejo", "Región del Biobío", "VIII" },
                    { 196, true, null, null, "Cobquecura", "Región del Biobío", "VIII" },
                    { 197, true, null, null, "Coelemu", "Región del Biobío", "VIII" },
                    { 198, true, null, null, "Coihueco", "Región del Biobío", "VIII" },
                    { 199, true, null, null, "Concepción", "Región del Biobío", "VIII" },
                    { 200, true, null, null, "Contulmo", "Región del Biobío", "VIII" },
                    { 201, true, null, null, "Coronel", "Región del Biobío", "VIII" },
                    { 202, true, null, null, "Curanilahue", "Región del Biobío", "VIII" },
                    { 203, true, null, null, "El Carmen", "Región del Biobío", "VIII" },
                    { 204, true, null, null, "Florida", "Región del Biobío", "VIII" },
                    { 205, true, null, null, "Hualpén", "Región del Biobío", "VIII" },
                    { 206, true, null, null, "Hualqui", "Región del Biobío", "VIII" },
                    { 207, true, null, null, "Laja", "Región del Biobío", "VIII" },
                    { 208, true, null, null, "Lebu", "Región del Biobío", "VIII" },
                    { 209, true, null, null, "Los Álamos", "Región del Biobío", "VIII" },
                    { 210, true, null, null, "Los Ángeles", "Región del Biobío", "VIII" },
                    { 211, true, null, null, "Lota", "Región del Biobío", "VIII" },
                    { 212, true, null, null, "Mulchén", "Región del Biobío", "VIII" },
                    { 213, true, null, null, "Nacimiento", "Región del Biobío", "VIII" },
                    { 214, true, null, null, "Negrete", "Región del Biobío", "VIII" },
                    { 215, true, null, null, "Ninhue", "Región del Biobío", "VIII" },
                    { 216, true, null, null, "Ñiquén", "Región del Biobío", "VIII" },
                    { 217, true, null, null, "Pemuco", "Región del Biobío", "VIII" },
                    { 218, true, null, null, "Penco", "Región del Biobío", "VIII" },
                    { 219, true, null, null, "Pinto", "Región del Biobío", "VIII" },
                    { 220, true, null, null, "Portezuelo", "Región del Biobío", "VIII" },
                    { 221, true, null, null, "Quilaco", "Región del Biobío", "VIII" },
                    { 222, true, null, null, "Quilleco", "Región del Biobío", "VIII" },
                    { 223, true, null, null, "Quillón", "Región del Biobío", "VIII" },
                    { 224, true, null, null, "Quirihue", "Región del Biobío", "VIII" },
                    { 225, true, null, null, "Ránquil", "Región del Biobío", "VIII" },
                    { 226, true, null, null, "San Carlos", "Región del Biobío", "VIII" },
                    { 227, true, null, null, "San Fabián", "Región del Biobío", "VIII" },
                    { 228, true, null, null, "San Ignacio", "Región del Biobío", "VIII" },
                    { 229, true, null, null, "San Nicolás", "Región del Biobío", "VIII" },
                    { 230, true, null, null, "San Pedro de la Paz", "Región del Biobío", "VIII" },
                    { 231, true, null, null, "San Rosendo", "Región del Biobío", "VIII" },
                    { 232, true, null, null, "Santa Bárbara", "Región del Biobío", "VIII" },
                    { 233, true, null, null, "Santa Juana", "Región del Biobío", "VIII" },
                    { 234, true, null, null, "Talcahuano", "Región del Biobío", "VIII" },
                    { 235, true, null, null, "Tirúa", "Región del Biobío", "VIII" },
                    { 236, true, null, null, "Tomé", "Región del Biobío", "VIII" },
                    { 237, true, null, null, "Treguaco", "Región del Biobío", "VIII" },
                    { 238, true, null, null, "Tucapel", "Región del Biobío", "VIII" },
                    { 239, true, null, null, "Yumbel", "Región del Biobío", "VIII" },
                    { 240, true, null, null, "Yungay", "Región del Biobío", "VIII" },
                    { 241, true, null, null, "Angol", "Región de La Araucanía", "IX" },
                    { 242, true, null, null, "Carahue", "Región de La Araucanía", "IX" },
                    { 243, true, null, null, "Cholchol", "Región de La Araucanía", "IX" },
                    { 244, true, null, null, "Collipulli", "Región de La Araucanía", "IX" },
                    { 245, true, null, null, "Cunco", "Región de La Araucanía", "IX" },
                    { 246, true, null, null, "Curacautín", "Región de La Araucanía", "IX" },
                    { 247, true, null, null, "Curarrehue", "Región de La Araucanía", "IX" },
                    { 248, true, null, null, "Ercilla", "Región de La Araucanía", "IX" },
                    { 249, true, null, null, "Freire", "Región de La Araucanía", "IX" },
                    { 250, true, null, null, "Galvarino", "Región de La Araucanía", "IX" },
                    { 251, true, null, null, "Gorbea", "Región de La Araucanía", "IX" },
                    { 252, true, null, null, "Lautaro", "Región de La Araucanía", "IX" },
                    { 253, true, null, null, "Loncoche", "Región de La Araucanía", "IX" },
                    { 254, true, null, null, "Lonquimay", "Región de La Araucanía", "IX" },
                    { 255, true, null, null, "Los Sauces", "Región de La Araucanía", "IX" },
                    { 256, true, null, null, "Lumaco", "Región de La Araucanía", "IX" },
                    { 257, true, null, null, "Melipeuco", "Región de La Araucanía", "IX" },
                    { 258, true, null, null, "Nueva Imperial", "Región de La Araucanía", "IX" },
                    { 259, true, null, null, "Padre Las Casas", "Región de La Araucanía", "IX" },
                    { 260, true, null, null, "Perquenco", "Región de La Araucanía", "IX" },
                    { 261, true, null, null, "Pitrufquén", "Región de La Araucanía", "IX" },
                    { 262, true, null, null, "Pucón", "Región de La Araucanía", "IX" },
                    { 263, true, null, null, "Purén", "Región de La Araucanía", "IX" },
                    { 264, true, null, null, "Renaico", "Región de La Araucanía", "IX" },
                    { 265, true, null, null, "Saavedra", "Región de La Araucanía", "IX" },
                    { 266, true, null, null, "Temuco", "Región de La Araucanía", "IX" },
                    { 267, true, null, null, "Teodoro Schmidt", "Región de La Araucanía", "IX" },
                    { 268, true, null, null, "Toltén", "Región de La Araucanía", "IX" },
                    { 269, true, null, null, "Traiguén", "Región de La Araucanía", "IX" },
                    { 270, true, null, null, "Victoria", "Región de La Araucanía", "IX" },
                    { 271, true, null, null, "Vilcún", "Región de La Araucanía", "IX" },
                    { 272, true, null, null, "Villarrica", "Región de La Araucanía", "IX" },
                    { 273, true, null, null, "Panguipulli", "Región de La Araucanía", "IX" },
                    { 274, true, null, null, "Ancud", "Región de Los Lagos", "X" },
                    { 275, true, null, null, "Calbuco", "Región de Los Lagos", "X" },
                    { 276, true, null, null, "Castro", "Región de Los Lagos", "X" },
                    { 277, true, null, null, "Chaitén", "Región de Los Lagos", "X" },
                    { 278, true, null, null, "Chonchi", "Región de Los Lagos", "X" },
                    { 279, true, null, null, "Cochamó", "Región de Los Lagos", "X" },
                    { 280, true, null, null, "Curaco de Vélez", "Región de Los Lagos", "X" },
                    { 281, true, null, null, "Dalcahue", "Región de Los Lagos", "X" },
                    { 282, true, null, null, "Fresia", "Región de Los Lagos", "X" },
                    { 283, true, null, null, "Frutillar", "Región de Los Lagos", "X" },
                    { 284, true, null, null, "Futaleufú", "Región de Los Lagos", "X" },
                    { 285, true, null, null, "Hualaihué", "Región de Los Lagos", "X" },
                    { 286, true, null, null, "Llanquihue", "Región de Los Lagos", "X" },
                    { 287, true, null, null, "Los Muermos", "Región de Los Lagos", "X" },
                    { 288, true, null, null, "Maullín", "Región de Los Lagos", "X" },
                    { 289, true, null, null, "Osorno", "Región de Los Lagos", "X" },
                    { 290, true, null, null, "Palena", "Región de Los Lagos", "X" },
                    { 291, true, null, null, "Puerto Montt", "Región de Los Lagos", "X" },
                    { 292, true, null, null, "Puerto Octay", "Región de Los Lagos", "X" },
                    { 293, true, null, null, "Puerto Varas", "Región de Los Lagos", "X" },
                    { 294, true, null, null, "Purranque", "Región de Los Lagos", "X" },
                    { 295, true, null, null, "Puyehue", "Región de Los Lagos", "X" },
                    { 296, true, null, null, "Queilén", "Región de Los Lagos", "X" },
                    { 297, true, null, null, "Quellón", "Región de Los Lagos", "X" },
                    { 298, true, null, null, "Quemchi", "Región de Los Lagos", "X" },
                    { 299, true, null, null, "Quinchao", "Región de Los Lagos", "X" },
                    { 300, true, null, null, "Río Negro", "Región de Los Lagos", "X" },
                    { 301, true, null, null, "San Juan de la Costa", "Región de Los Lagos", "X" },
                    { 302, true, null, null, "San Pablo", "Región de Los Lagos", "X" },
                    { 303, true, null, null, "Toltén", "Región de Los Lagos", "X" },
                    { 304, true, null, null, "Vilcún", "Región de Los Lagos", "X" },
                    { 305, true, null, null, "Villarrica", "Región de Los Lagos", "X" },
                    { 306, true, null, null, "Panguipulli", "Región de Los Lagos", "X" },
                    { 307, true, null, null, "Aysén", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 308, true, null, null, "Chile Chico", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 309, true, null, null, "Cisnes", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 310, true, null, null, "Cochrane", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 311, true, null, null, "Coyhaique", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 312, true, null, null, "Guaitecas", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 313, true, null, null, "Lago Verde", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 314, true, null, null, "OHiggins", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 315, true, null, null, "Río Ibáñez", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 316, true, null, null, "Tortel", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 317, true, null, null, "Antártica", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 318, true, null, null, "Cabo de Hornos", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 319, true, null, null, "Laguna Blanca", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 320, true, null, null, "Natales", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 321, true, null, null, "Porvenir", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 322, true, null, null, "Primavera", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 323, true, null, null, "Punta Arenas", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 324, true, null, null, "Río Verde", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 325, true, null, null, "San Gregorio", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 326, true, null, null, "Timaukel", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 327, true, null, null, "Torres del Paine", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 328, true, null, null, "Corral", "Región de Los Ríos", "XIV" },
                    { 329, true, null, null, "Futrono", "Región de Los Ríos", "XIV" },
                    { 330, true, null, null, "La Unión", "Región de Los Ríos", "XIV" },
                    { 331, true, null, null, "Lago Ranco", "Región de Los Ríos", "XIV" },
                    { 332, true, null, null, "Lanco", "Región de Los Ríos", "XIV" },
                    { 333, true, null, null, "Los Lagos", "Región de Los Ríos", "XIV" },
                    { 334, true, null, null, "Máfil", "Región de Los Ríos", "XIV" },
                    { 335, true, null, null, "Mariquina", "Región de Los Ríos", "XIV" },
                    { 336, true, null, null, "Paillaco", "Región de Los Ríos", "XIV" },
                    { 337, true, null, null, "Panguipulli", "Región de Los Ríos", "XIV" },
                    { 338, true, null, null, "Río Bueno", "Región de Los Ríos", "XIV" },
                    { 339, true, null, null, "Valdivia", "Región de Los Ríos", "XIV" },
                    { 340, true, null, null, "Arica", "Región de Arica y Parinacota", "XV" },
                    { 341, true, null, null, "Camarones", "Región de Arica y Parinacota", "XV" },
                    { 342, true, null, null, "General Lagos", "Región de Arica y Parinacota", "XV" },
                    { 343, true, null, null, "Putre", "Región de Arica y Parinacota", "XV" },
                    { 344, true, null, null, "Bulnes", "Región de Ñuble", "XVI" },
                    { 345, true, null, null, "Chillán", "Región de Ñuble", "XVI" },
                    { 346, true, null, null, "Chillán Viejo", "Región de Ñuble", "XVI" },
                    { 347, true, null, null, "Cobquecura", "Región de Ñuble", "XVI" },
                    { 348, true, null, null, "Coelemu", "Región de Ñuble", "XVI" },
                    { 349, true, null, null, "Coihueco", "Región de Ñuble", "XVI" },
                    { 350, true, null, null, "El Carmen", "Región de Ñuble", "XVI" },
                    { 351, true, null, null, "Ninhue", "Región de Ñuble", "XVI" },
                    { 352, true, null, null, "Ñiquén", "Región de Ñuble", "XVI" },
                    { 353, true, null, null, "Pemuco", "Región de Ñuble", "XVI" },
                    { 354, true, null, null, "Pinto", "Región de Ñuble", "XVI" },
                    { 355, true, null, null, "Portezuelo", "Región de Ñuble", "XVI" },
                    { 356, true, null, null, "Quillón", "Región de Ñuble", "XVI" },
                    { 357, true, null, null, "Quirihue", "Región de Ñuble", "XVI" },
                    { 358, true, null, null, "Ránquil", "Región de Ñuble", "XVI" },
                    { 359, true, null, null, "San Carlos", "Región de Ñuble", "XVI" },
                    { 360, true, null, null, "San Fabián", "Región de Ñuble", "XVI" },
                    { 361, true, null, null, "San Ignacio", "Región de Ñuble", "XVI" },
                    { 362, true, null, null, "San Nicolás", "Región de Ñuble", "XVI" },
                    { 363, true, null, null, "Treguaco", "Región de Ñuble", "XVI" },
                    { 364, true, null, null, "Yungay", "Región de Ñuble", "XVI" }
                });

            migrationBuilder.InsertData(
                table: "EstadoAgendaMedico",
                columns: new[] { "IdEstadoAgendaMedico", "EsActivo", "FecActualizacion", "FecCreacion", "NombreEstadoAgendaMedico" },
                values: new object[,]
                {
                    { 1, true, null, null, "Disponible" },
                    { 2, true, null, null, "Ocupado" },
                    { 3, true, null, null, "De Vacaciones" },
                    { 4, true, null, null, "Con Licencia Médica" },
                    { 5, true, null, null, "Medio Día Ocupado" }
                });

            migrationBuilder.InsertData(
                table: "EstadoFichaClinica",
                columns: new[] { "IdEstadoFichaClinica", "EsActivo", "FecActualizacion", "FecCreacion", "NombreEstadoFichaClinica" },
                values: new object[,]
                {
                    { 1, true, null, null, "En Proceso" },
                    { 2, true, null, null, "Completado" },
                    { 3, true, null, null, "Cancelado" },
                    { 4, true, null, null, "En Revisión" },
                    { 5, true, null, null, "Aprobado" },
                    { 6, true, null, null, "Pendiente" },
                    { 7, true, null, null, "Rechazado" },
                    { 8, true, null, null, "Cerrado" },
                    { 9, true, null, null, "Archivado" }
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
                name: "IX_Modulo_IdLugarAtencion",
                table: "Modulo",
                column: "IdLugarAtencion");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteAdultoMayor_IdPaciente",
                table: "PacienteAdultoMayor",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteDiabetico_IdPaciente",
                table: "PacienteDiabetico",
                column: "IdPaciente");

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
