using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AtencionMedica.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDbSeedersBase : Migration
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
                    NombreComuna = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    SiglaRegion = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
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
                    NombreEspecialidad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
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
                    NombreEstadoAgendaMedico = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
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
                    NombreEstadoFichaClinica = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
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
                    NombreMedicamento = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
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
                    Rut = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Dv = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Nombres = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Correo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
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
                    Rut = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Dv = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Nombres = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Rut = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Dv = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Nombres = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Correo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
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
                    NombreLugar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Fono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    HorarioAtencion = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
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
                    FecComplicacion = table.Column<DateTime>(type: "datetime", unicode: false, nullable: false)
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
                    Dependencia = table.Column<bool>(type: "bit", nullable: false)
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
                    FecRetinopatia = table.Column<DateTime>(type: "datetime", unicode: false, nullable: true)
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
                    IdPatologiaPaciente = table.Column<long>(type: "bigint", nullable: false)
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
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
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
                    IdHistorialClinico = table.Column<long>(type: "bigint", nullable: false),
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
                    IdFichaClinica = table.Column<long>(type: "bigint", nullable: false)
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
                    IdFichaClinicaDetalle = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFichaClinica = table.Column<long>(type: "bigint", nullable: false),
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
                columns: new[] { "IdComuna", "EsActivo", "NombreComuna", "Region", "SiglaRegion" },
                values: new object[,]
                {
                    { 1, true, "Arica", "Región de Tarapacá", "I" },
                    { 2, true, "Camarones", "Región de Tarapacá", "I" },
                    { 3, true, "Alto Hospicio", "Región de Antofagasta", "II" },
                    { 4, true, "Iquique", "Región de Antofagasta", "II" },
                    { 5, true, "Camiña", "Región de Antofagasta", "II" },
                    { 6, true, "Colchane", "Región de Antofagasta", "II" },
                    { 7, true, "Huara", "Región de Antofagasta", "II" },
                    { 8, true, "Pica", "Región de Antofagasta", "II" },
                    { 9, true, "Pozo Almonte", "Región de Antofagasta", "II" },
                    { 10, true, "Caldera", "Región de Atacama", "III" },
                    { 11, true, "Chanaral", "Región de Atacama", "III" },
                    { 12, true, "Copiapó", "Región de Atacama", "III" },
                    { 13, true, "Diego de Almagro", "Región de Atacama", "III" },
                    { 14, true, "Freirina", "Región de Atacama", "III" },
                    { 15, true, "Huasco", "Región de Atacama", "III" },
                    { 16, true, "Tierra Amarilla", "Región de Atacama", "III" },
                    { 17, true, "Vallenar", "Región de Atacama", "III" },
                    { 18, true, "Andacollo", "Región de Coquimbo", "IV" },
                    { 19, true, "Canela", "Región de Coquimbo", "IV" },
                    { 20, true, "Combarbalá", "Región de Coquimbo", "IV" },
                    { 21, true, "Coquimbo", "Región de Coquimbo", "IV" },
                    { 22, true, "Illapel", "Región de Coquimbo", "IV" },
                    { 23, true, "La Higuera", "Región de Coquimbo", "IV" },
                    { 24, true, "La Serena", "Región de Coquimbo", "IV" },
                    { 25, true, "Los Vilos", "Región de Coquimbo", "IV" },
                    { 26, true, "Monte Patria", "Región de Coquimbo", "IV" },
                    { 27, true, "Ovalle", "Región de Coquimbo", "IV" },
                    { 28, true, "Paihuano", "Región de Coquimbo", "IV" },
                    { 29, true, "Punitaqui", "Región de Coquimbo", "IV" },
                    { 30, true, "Río Hurtado", "Región de Coquimbo", "IV" },
                    { 31, true, "Salamanca", "Región de Coquimbo", "IV" },
                    { 32, true, "Vicuña", "Región de Coquimbo", "IV" },
                    { 33, true, "Algarrobo", "Región de Valparaíso", "V" },
                    { 34, true, "Cabildo", "Región de Valparaíso", "V" },
                    { 35, true, "Calera", "Región de Valparaíso", "V" },
                    { 36, true, "Calle Larga", "Región de Valparaíso", "V" },
                    { 37, true, "Cartagena", "Región de Valparaíso", "V" },
                    { 38, true, "Casablanca", "Región de Valparaíso", "V" },
                    { 39, true, "Catemu", "Región de Valparaíso", "V" },
                    { 40, true, "Concón", "Región de Valparaíso", "V" },
                    { 41, true, "El Quisco", "Región de Valparaíso", "V" },
                    { 42, true, "El Tabo", "Región de Valparaíso", "V" },
                    { 43, true, "Hijuelas", "Región de Valparaíso", "V" },
                    { 44, true, "Isla de Pascua", "Región de Valparaíso", "V" },
                    { 45, true, "Juan Fernández", "Región de Valparaíso", "V" },
                    { 46, true, "La Cruz", "Región de Valparaíso", "V" },
                    { 47, true, "La Ligua", "Región de Valparaíso", "V" },
                    { 48, true, "Limache", "Región de Valparaíso", "V" },
                    { 49, true, "Llaillay", "Región de Valparaíso", "V" },
                    { 50, true, "Los Andes", "Región de Valparaíso", "V" },
                    { 51, true, "Nogales", "Región de Valparaíso", "V" },
                    { 52, true, "Olmué", "Región de Valparaíso", "V" },
                    { 53, true, "Panquehue", "Región de Valparaíso", "V" },
                    { 54, true, "Papudo", "Región de Valparaíso", "V" },
                    { 55, true, "Petorca", "Región de Valparaíso", "V" },
                    { 56, true, "Puchuncaví", "Región de Valparaíso", "V" },
                    { 57, true, "Putaendo", "Región de Valparaíso", "V" },
                    { 58, true, "Quillota", "Región de Valparaíso", "V" },
                    { 59, true, "Quilpué", "Región de Valparaíso", "V" },
                    { 60, true, "Quintero", "Región de Valparaíso", "V" },
                    { 61, true, "Rinconada", "Región de Valparaíso", "V" },
                    { 62, true, "San Antonio", "Región de Valparaíso", "V" },
                    { 63, true, "San Esteban", "Región de Valparaíso", "V" },
                    { 64, true, "San Felipe", "Región de Valparaíso", "V" },
                    { 65, true, "Santa María", "Región de Valparaíso", "V" },
                    { 66, true, "Santo Domingo", "Región de Valparaíso", "V" },
                    { 67, true, "Valparaíso", "Región de Valparaíso", "V" },
                    { 68, true, "Villa Alemana", "Región de Valparaíso", "V" },
                    { 69, true, "Viña del Mar", "Región de Valparaíso", "V" },
                    { 70, true, "Zapallar", "Región de Valparaíso", "V" },
                    { 71, true, "Alhué", "Región Metropolitana de Santiago", "RM" },
                    { 72, true, "Buin", "Región Metropolitana de Santiago", "RM" },
                    { 73, true, "Calera de Tango", "Región Metropolitana de Santiago", "RM" },
                    { 74, true, "Cerrillos", "Región Metropolitana de Santiago", "RM" },
                    { 75, true, "Cerro Navia", "Región Metropolitana de Santiago", "RM" },
                    { 76, true, "Colina", "Región Metropolitana de Santiago", "RM" },
                    { 77, true, "Conchalí", "Región Metropolitana de Santiago", "RM" },
                    { 78, true, "Curacaví", "Región Metropolitana de Santiago", "RM" },
                    { 79, true, "El Bosque", "Región Metropolitana de Santiago", "RM" },
                    { 80, true, "El Monte", "Región Metropolitana de Santiago", "RM" },
                    { 81, true, "Estación Central", "Región Metropolitana de Santiago", "RM" },
                    { 82, true, "Huechuraba", "Región Metropolitana de Santiago", "RM" },
                    { 83, true, "Independencia", "Región Metropolitana de Santiago", "RM" },
                    { 84, true, "Isla de Maipo", "Región Metropolitana de Santiago", "RM" },
                    { 85, true, "La Cisterna", "Región Metropolitana de Santiago", "RM" },
                    { 86, true, "La Florida", "Región Metropolitana de Santiago", "RM" },
                    { 87, true, "La Granja", "Región Metropolitana de Santiago", "RM" },
                    { 88, true, "La Pintana", "Región Metropolitana de Santiago", "RM" },
                    { 89, true, "La Reina", "Región Metropolitana de Santiago", "RM" },
                    { 90, true, "Lampa", "Región Metropolitana de Santiago", "RM" },
                    { 91, true, "Las Condes", "Región Metropolitana de Santiago", "RM" },
                    { 92, true, "Lo Barnechea", "Región Metropolitana de Santiago", "RM" },
                    { 93, true, "Lo Espejo", "Región Metropolitana de Santiago", "RM" },
                    { 94, true, "Lo Prado", "Región Metropolitana de Santiago", "RM" },
                    { 95, true, "Macul", "Región Metropolitana de Santiago", "RM" },
                    { 96, true, "Maipú", "Región Metropolitana de Santiago", "RM" },
                    { 97, true, "María Pinto", "Región Metropolitana de Santiago", "RM" },
                    { 98, true, "Melipilla", "Región Metropolitana de Santiago", "RM" },
                    { 99, true, "Ñuñoa", "Región Metropolitana de Santiago", "RM" },
                    { 100, true, "Padre Hurtado", "Región Metropolitana de Santiago", "RM" },
                    { 101, true, "Paine", "Región Metropolitana de Santiago", "RM" },
                    { 102, true, "Pedro Aguirre Cerda", "Región Metropolitana de Santiago", "RM" },
                    { 103, true, "Peñaflor", "Región Metropolitana de Santiago", "RM" },
                    { 104, true, "Peñalolén", "Región Metropolitana de Santiago", "RM" },
                    { 105, true, "Pirque", "Región Metropolitana de Santiago", "RM" },
                    { 106, true, "Providencia", "Región Metropolitana de Santiago", "RM" },
                    { 107, true, "Pudahuel", "Región Metropolitana de Santiago", "RM" },
                    { 108, true, "Puente Alto", "Región Metropolitana de Santiago", "RM" },
                    { 109, true, "Quilicura", "Región Metropolitana de Santiago", "RM" },
                    { 110, true, "Quinta Normal", "Región Metropolitana de Santiago", "RM" },
                    { 111, true, "Recoleta", "Región Metropolitana de Santiago", "RM" },
                    { 112, true, "Renca", "Región Metropolitana de Santiago", "RM" },
                    { 113, true, "San Bernardo", "Región Metropolitana de Santiago", "RM" },
                    { 114, true, "San Joaquín", "Región Metropolitana de Santiago", "RM" },
                    { 115, true, "San José de Maipo", "Región Metropolitana de Santiago", "RM" },
                    { 116, true, "San Miguel", "Región Metropolitana de Santiago", "RM" },
                    { 117, true, "San Pedro", "Región Metropolitana de Santiago", "RM" },
                    { 118, true, "San Ramón", "Región Metropolitana de Santiago", "RM" },
                    { 119, true, "Santiago", "Región Metropolitana de Santiago", "RM" },
                    { 120, true, "Talagante", "Región Metropolitana de Santiago", "RM" },
                    { 121, true, "Tiltil", "Región Metropolitana de Santiago", "RM" },
                    { 122, true, "Vitacura", "Región Metropolitana de Santiago", "RM" },
                    { 123, true, "Cachapoal", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 124, true, "Cardenal Caro", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 125, true, "Chépica", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 126, true, "Chimbarongo", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 127, true, "Codegua", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 128, true, "Coinco", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 129, true, "Coltauco", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 130, true, "Doñihue", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 131, true, "Graneros", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 132, true, "La Estrella", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 133, true, "Las Cabras", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 134, true, "Litueche", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 135, true, "Lolol", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 136, true, "Machalí", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 137, true, "Malloa", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 138, true, "Marchihue", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 139, true, "Nancagua", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 140, true, "Navidad", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 141, true, "Olivar", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 142, true, "Palmilla", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 143, true, "Paredones", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 144, true, "Peralillo", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 145, true, "Peumo", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 146, true, "Pichidegua", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 147, true, "Pichilemu", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 148, true, "Placilla", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 149, true, "Pumanque", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 150, true, "Quinta de Tilcoco", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 151, true, "Rancagua", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 152, true, "Rengo", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 153, true, "Requínoa", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 154, true, "San Fernando", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 155, true, "San Vicente de Tagua Tagua", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 156, true, "Santa Cruz", "Región del Libertador General Bernardo O'Higgins", "VI" },
                    { 157, true, "Cauquenes", "Región del Maule", "VII" },
                    { 158, true, "Chanco", "Región del Maule", "VII" },
                    { 159, true, "Colbún", "Región del Maule", "VII" },
                    { 160, true, "Constitución", "Región del Maule", "VII" },
                    { 161, true, "Curepto", "Región del Maule", "VII" },
                    { 162, true, "Curicó", "Región del Maule", "VII" },
                    { 163, true, "Empedrado", "Región del Maule", "VII" },
                    { 164, true, "Hualañé", "Región del Maule", "VII" },
                    { 165, true, "Licantén", "Región del Maule", "VII" },
                    { 166, true, "Linares", "Región del Maule", "VII" },
                    { 167, true, "Longaví", "Región del Maule", "VII" },
                    { 168, true, "Maule", "Región del Maule", "VII" },
                    { 169, true, "Molina", "Región del Maule", "VII" },
                    { 170, true, "Parral", "Región del Maule", "VII" },
                    { 171, true, "Pelarco", "Región del Maule", "VII" },
                    { 172, true, "Pelluhue", "Región del Maule", "VII" },
                    { 173, true, "Pencahue", "Región del Maule", "VII" },
                    { 174, true, "Rauco", "Región del Maule", "VII" },
                    { 175, true, "Retiro", "Región del Maule", "VII" },
                    { 176, true, "Romeral", "Región del Maule", "VII" },
                    { 177, true, "Sagrada Familia", "Región del Maule", "VII" },
                    { 178, true, "San Clemente", "Región del Maule", "VII" },
                    { 179, true, "San Javier", "Región del Maule", "VII" },
                    { 180, true, "San Rafael", "Región del Maule", "VII" },
                    { 181, true, "Santa Cruz", "Región del Maule", "VII" },
                    { 182, true, "Talca", "Región del Maule", "VII" },
                    { 183, true, "Teno", "Región del Maule", "VII" },
                    { 184, true, "Vichuquén", "Región del Maule", "VII" },
                    { 185, true, "Villa Alegre", "Región del Maule", "VII" },
                    { 186, true, "Yerbas Buenas", "Región del Maule", "VII" },
                    { 187, true, "Alto Biobío", "Región del Biobío", "VIII" },
                    { 188, true, "Antuco", "Región del Biobío", "VIII" },
                    { 189, true, "Arauco", "Región del Biobío", "VIII" },
                    { 190, true, "Bulnes", "Región del Biobío", "VIII" },
                    { 191, true, "Cabrero", "Región del Biobío", "VIII" },
                    { 192, true, "Cañete", "Región del Biobío", "VIII" },
                    { 193, true, "Chiguayante", "Región del Biobío", "VIII" },
                    { 194, true, "Chillán", "Región del Biobío", "VIII" },
                    { 195, true, "Chillán Viejo", "Región del Biobío", "VIII" },
                    { 196, true, "Cobquecura", "Región del Biobío", "VIII" },
                    { 197, true, "Coelemu", "Región del Biobío", "VIII" },
                    { 198, true, "Coihueco", "Región del Biobío", "VIII" },
                    { 199, true, "Concepción", "Región del Biobío", "VIII" },
                    { 200, true, "Contulmo", "Región del Biobío", "VIII" },
                    { 201, true, "Coronel", "Región del Biobío", "VIII" },
                    { 202, true, "Curanilahue", "Región del Biobío", "VIII" },
                    { 203, true, "El Carmen", "Región del Biobío", "VIII" },
                    { 204, true, "Florida", "Región del Biobío", "VIII" },
                    { 205, true, "Hualpén", "Región del Biobío", "VIII" },
                    { 206, true, "Hualqui", "Región del Biobío", "VIII" },
                    { 207, true, "Laja", "Región del Biobío", "VIII" },
                    { 208, true, "Lebu", "Región del Biobío", "VIII" },
                    { 209, true, "Los Álamos", "Región del Biobío", "VIII" },
                    { 210, true, "Los Ángeles", "Región del Biobío", "VIII" },
                    { 211, true, "Lota", "Región del Biobío", "VIII" },
                    { 212, true, "Mulchén", "Región del Biobío", "VIII" },
                    { 213, true, "Nacimiento", "Región del Biobío", "VIII" },
                    { 214, true, "Negrete", "Región del Biobío", "VIII" },
                    { 215, true, "Ninhue", "Región del Biobío", "VIII" },
                    { 216, true, "Ñiquén", "Región del Biobío", "VIII" },
                    { 217, true, "Pemuco", "Región del Biobío", "VIII" },
                    { 218, true, "Penco", "Región del Biobío", "VIII" },
                    { 219, true, "Pinto", "Región del Biobío", "VIII" },
                    { 220, true, "Portezuelo", "Región del Biobío", "VIII" },
                    { 221, true, "Quilaco", "Región del Biobío", "VIII" },
                    { 222, true, "Quilleco", "Región del Biobío", "VIII" },
                    { 223, true, "Quillón", "Región del Biobío", "VIII" },
                    { 224, true, "Quirihue", "Región del Biobío", "VIII" },
                    { 225, true, "Ránquil", "Región del Biobío", "VIII" },
                    { 226, true, "San Carlos", "Región del Biobío", "VIII" },
                    { 227, true, "San Fabián", "Región del Biobío", "VIII" },
                    { 228, true, "San Ignacio", "Región del Biobío", "VIII" },
                    { 229, true, "San Nicolás", "Región del Biobío", "VIII" },
                    { 230, true, "San Pedro de la Paz", "Región del Biobío", "VIII" },
                    { 231, true, "San Rosendo", "Región del Biobío", "VIII" },
                    { 232, true, "Santa Bárbara", "Región del Biobío", "VIII" },
                    { 233, true, "Santa Juana", "Región del Biobío", "VIII" },
                    { 234, true, "Talcahuano", "Región del Biobío", "VIII" },
                    { 235, true, "Tirúa", "Región del Biobío", "VIII" },
                    { 236, true, "Tomé", "Región del Biobío", "VIII" },
                    { 237, true, "Treguaco", "Región del Biobío", "VIII" },
                    { 238, true, "Tucapel", "Región del Biobío", "VIII" },
                    { 239, true, "Yumbel", "Región del Biobío", "VIII" },
                    { 240, true, "Yungay", "Región del Biobío", "VIII" },
                    { 241, true, "Angol", "Región de La Araucanía", "IX" },
                    { 242, true, "Carahue", "Región de La Araucanía", "IX" },
                    { 243, true, "Cholchol", "Región de La Araucanía", "IX" },
                    { 244, true, "Collipulli", "Región de La Araucanía", "IX" },
                    { 245, true, "Cunco", "Región de La Araucanía", "IX" },
                    { 246, true, "Curacautín", "Región de La Araucanía", "IX" },
                    { 247, true, "Curarrehue", "Región de La Araucanía", "IX" },
                    { 248, true, "Ercilla", "Región de La Araucanía", "IX" },
                    { 249, true, "Freire", "Región de La Araucanía", "IX" },
                    { 250, true, "Galvarino", "Región de La Araucanía", "IX" },
                    { 251, true, "Gorbea", "Región de La Araucanía", "IX" },
                    { 252, true, "Lautaro", "Región de La Araucanía", "IX" },
                    { 253, true, "Loncoche", "Región de La Araucanía", "IX" },
                    { 254, true, "Lonquimay", "Región de La Araucanía", "IX" },
                    { 255, true, "Los Sauces", "Región de La Araucanía", "IX" },
                    { 256, true, "Lumaco", "Región de La Araucanía", "IX" },
                    { 257, true, "Melipeuco", "Región de La Araucanía", "IX" },
                    { 258, true, "Nueva Imperial", "Región de La Araucanía", "IX" },
                    { 259, true, "Padre Las Casas", "Región de La Araucanía", "IX" },
                    { 260, true, "Perquenco", "Región de La Araucanía", "IX" },
                    { 261, true, "Pitrufquén", "Región de La Araucanía", "IX" },
                    { 262, true, "Pucón", "Región de La Araucanía", "IX" },
                    { 263, true, "Purén", "Región de La Araucanía", "IX" },
                    { 264, true, "Renaico", "Región de La Araucanía", "IX" },
                    { 265, true, "Saavedra", "Región de La Araucanía", "IX" },
                    { 266, true, "Temuco", "Región de La Araucanía", "IX" },
                    { 267, true, "Teodoro Schmidt", "Región de La Araucanía", "IX" },
                    { 268, true, "Toltén", "Región de La Araucanía", "IX" },
                    { 269, true, "Traiguén", "Región de La Araucanía", "IX" },
                    { 270, true, "Victoria", "Región de La Araucanía", "IX" },
                    { 271, true, "Vilcún", "Región de La Araucanía", "IX" },
                    { 272, true, "Villarrica", "Región de La Araucanía", "IX" },
                    { 273, true, "Panguipulli", "Región de La Araucanía", "IX" },
                    { 274, true, "Ancud", "Región de Los Lagos", "X" },
                    { 275, true, "Calbuco", "Región de Los Lagos", "X" },
                    { 276, true, "Castro", "Región de Los Lagos", "X" },
                    { 277, true, "Chaitén", "Región de Los Lagos", "X" },
                    { 278, true, "Chonchi", "Región de Los Lagos", "X" },
                    { 279, true, "Cochamó", "Región de Los Lagos", "X" },
                    { 280, true, "Curaco de Vélez", "Región de Los Lagos", "X" },
                    { 281, true, "Dalcahue", "Región de Los Lagos", "X" },
                    { 282, true, "Fresia", "Región de Los Lagos", "X" },
                    { 283, true, "Frutillar", "Región de Los Lagos", "X" },
                    { 284, true, "Futaleufú", "Región de Los Lagos", "X" },
                    { 285, true, "Hualaihué", "Región de Los Lagos", "X" },
                    { 286, true, "Llanquihue", "Región de Los Lagos", "X" },
                    { 287, true, "Los Muermos", "Región de Los Lagos", "X" },
                    { 288, true, "Maullín", "Región de Los Lagos", "X" },
                    { 289, true, "Osorno", "Región de Los Lagos", "X" },
                    { 290, true, "Palena", "Región de Los Lagos", "X" },
                    { 291, true, "Puerto Montt", "Región de Los Lagos", "X" },
                    { 292, true, "Puerto Octay", "Región de Los Lagos", "X" },
                    { 293, true, "Puerto Varas", "Región de Los Lagos", "X" },
                    { 294, true, "Purranque", "Región de Los Lagos", "X" },
                    { 295, true, "Puyehue", "Región de Los Lagos", "X" },
                    { 296, true, "Queilén", "Región de Los Lagos", "X" },
                    { 297, true, "Quellón", "Región de Los Lagos", "X" },
                    { 298, true, "Quemchi", "Región de Los Lagos", "X" },
                    { 299, true, "Quinchao", "Región de Los Lagos", "X" },
                    { 300, true, "Río Negro", "Región de Los Lagos", "X" },
                    { 301, true, "San Juan de la Costa", "Región de Los Lagos", "X" },
                    { 302, true, "San Pablo", "Región de Los Lagos", "X" },
                    { 303, true, "Toltén", "Región de Los Lagos", "X" },
                    { 304, true, "Vilcún", "Región de Los Lagos", "X" },
                    { 305, true, "Villarrica", "Región de Los Lagos", "X" },
                    { 306, true, "Panguipulli", "Región de Los Lagos", "X" },
                    { 307, true, "Aysén", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 308, true, "Chile Chico", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 309, true, "Cisnes", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 310, true, "Cochrane", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 311, true, "Coyhaique", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 312, true, "Guaitecas", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 313, true, "Lago Verde", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 314, true, "OHiggins", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 315, true, "Río Ibáñez", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 316, true, "Tortel", "Región de Aysén del General Carlos Ibáñez del Campo", "XI" },
                    { 317, true, "Antártica", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 318, true, "Cabo de Hornos", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 319, true, "Laguna Blanca", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 320, true, "Natales", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 321, true, "Porvenir", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 322, true, "Primavera", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 323, true, "Punta Arenas", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 324, true, "Río Verde", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 325, true, "San Gregorio", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 326, true, "Timaukel", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 327, true, "Torres del Paine", "Región de Magallanes y de la Antártica Chilena", "XII" },
                    { 328, true, "Corral", "Región de Los Ríos", "XIV" },
                    { 329, true, "Futrono", "Región de Los Ríos", "XIV" },
                    { 330, true, "La Unión", "Región de Los Ríos", "XIV" },
                    { 331, true, "Lago Ranco", "Región de Los Ríos", "XIV" },
                    { 332, true, "Lanco", "Región de Los Ríos", "XIV" },
                    { 333, true, "Los Lagos", "Región de Los Ríos", "XIV" },
                    { 334, true, "Máfil", "Región de Los Ríos", "XIV" },
                    { 335, true, "Mariquina", "Región de Los Ríos", "XIV" },
                    { 336, true, "Paillaco", "Región de Los Ríos", "XIV" },
                    { 337, true, "Panguipulli", "Región de Los Ríos", "XIV" },
                    { 338, true, "Río Bueno", "Región de Los Ríos", "XIV" },
                    { 339, true, "Valdivia", "Región de Los Ríos", "XIV" },
                    { 340, true, "Arica", "Región de Arica y Parinacota", "XV" },
                    { 341, true, "Camarones", "Región de Arica y Parinacota", "XV" },
                    { 342, true, "General Lagos", "Región de Arica y Parinacota", "XV" },
                    { 343, true, "Putre", "Región de Arica y Parinacota", "XV" },
                    { 344, true, "Bulnes", "Región de Ñuble", "XVI" },
                    { 345, true, "Chillán", "Región de Ñuble", "XVI" },
                    { 346, true, "Chillán Viejo", "Región de Ñuble", "XVI" },
                    { 347, true, "Cobquecura", "Región de Ñuble", "XVI" },
                    { 348, true, "Coelemu", "Región de Ñuble", "XVI" },
                    { 349, true, "Coihueco", "Región de Ñuble", "XVI" },
                    { 350, true, "El Carmen", "Región de Ñuble", "XVI" },
                    { 351, true, "Ninhue", "Región de Ñuble", "XVI" },
                    { 352, true, "Ñiquén", "Región de Ñuble", "XVI" },
                    { 353, true, "Pemuco", "Región de Ñuble", "XVI" },
                    { 354, true, "Pinto", "Región de Ñuble", "XVI" },
                    { 355, true, "Portezuelo", "Región de Ñuble", "XVI" },
                    { 356, true, "Quillón", "Región de Ñuble", "XVI" },
                    { 357, true, "Quirihue", "Región de Ñuble", "XVI" },
                    { 358, true, "Ránquil", "Región de Ñuble", "XVI" },
                    { 359, true, "San Carlos", "Región de Ñuble", "XVI" },
                    { 360, true, "San Fabián", "Región de Ñuble", "XVI" },
                    { 361, true, "San Ignacio", "Región de Ñuble", "XVI" },
                    { 362, true, "San Nicolás", "Región de Ñuble", "XVI" },
                    { 363, true, "Treguaco", "Región de Ñuble", "XVI" },
                    { 364, true, "Yungay", "Región de Ñuble", "XVI" }
                });

            migrationBuilder.InsertData(
                table: "EstadoAgendaMedico",
                columns: new[] { "IdEstadoAgendaMedico", "EsActivo", "NombreEstadoAgendaMedico" },
                values: new object[,]
                {
                    { 1, true, "Disponible" },
                    { 2, true, "Ocupado" },
                    { 3, true, "De Vacaciones" },
                    { 4, true, "Con Licencia Médica" },
                    { 5, true, "Medio Día Ocupado" }
                });

            migrationBuilder.InsertData(
                table: "EstadoFichaClinica",
                columns: new[] { "IdEstadoFichaClinica", "EsActivo", "NombreEstadoFichaClinica" },
                values: new object[,]
                {
                    { 1, true, "En Proceso" },
                    { 2, true, "Completado" },
                    { 3, true, "Cancelado" },
                    { 4, true, "En Revisión" },
                    { 5, true, "Aprobado" },
                    { 6, true, "Pendiente" },
                    { 7, true, "Rechazado" },
                    { 8, true, "Cerrado" },
                    { 9, true, "Archivado" }
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
