using System.Reflection;

namespace AtencionMedica.Infraestructure.Data
{
    public class AtencionMedicaContext : DbContext
    {
        public AtencionMedicaContext(DbContextOptions<AtencionMedicaContext> options) : base(options)
        {
        }

        public DbSet<AgendaMedico> AgendaMedicos { get; set; }
        public DbSet<Complicacion> Complicaciones { get; set; }
        public DbSet<ComplicacionPaciente> ComplicacionPacientes { get; set; }
        public DbSet<Comuna> Comunas { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<EspecialidadMedico> EspecialidadMedicos { get; set; }
        public DbSet<EstadoAgendaMedico> EstadoAgendaMedicos { get; set; }
        public DbSet<EstadoFichaClinica> EstadoFichaClinicas { get; set; }
        public DbSet<FichaClinica> FichaClinicas { get; set; }
        public DbSet<FichaClinicaDetalle> FichaClinicaDetalles { get; set; }
        public DbSet<HistorialClinico> HistorialClinicos { get; set; }
        public DbSet<LugarAtencion> LugarAtenciones { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PacienteAdultoMayor> PacienteAdultoMayores { get; set; }
        public DbSet<PacienteDiabetico> PacienteDiabeticos { get; set; }
        public DbSet<Patologia> Patologias { get; set; }
        public DbSet<PatologiaPaciente> PatologiaPacientes { get; set; }
        public DbSet<Personal> Personales { get; set; }
        public DbSet<RecetaMedica> RecetaMedicas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json")
                   .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("AtencionMedicaConnection"));
            }
        }
    }
}
