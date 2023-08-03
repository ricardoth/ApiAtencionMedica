using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            //base.OnModelCreating(modelBuilder);
            //AgendaMedico

            modelBuilder.Entity<AgendaMedico>()
            .HasKey(e => e.IdAgendaMedico);

            modelBuilder.Entity<AgendaMedico>().ToTable("AgendaMedico");

            modelBuilder.Entity<AgendaMedico>().HasOne(c => c.Medico)
                .WithMany(p => p.AgendaMedicos)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgendaMedico_Medico");

            modelBuilder.Entity<AgendaMedico>().HasOne(c => c.EstadoAgendaMedico)
                .WithMany(p => p.AgendaMedicos)
                .HasForeignKey(d => d.IdEstadoAgendaMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgendaMedico_EstadoAgendaMedico");

            //PatologiaPaciente
            modelBuilder.Entity<PatologiaPaciente>()
            .HasKey(e => e.IdPatologiaPaciente);

            modelBuilder.Entity<PatologiaPaciente>().ToTable("PatologiaPaciente");

            modelBuilder.Entity<PatologiaPaciente>().HasOne(c => c.Paciente)
                .WithMany(p => p.PatologiaPacientes)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatologiaPaciente_Paciente");

            modelBuilder.Entity<PatologiaPaciente>().HasOne(c => c.Patologia)
                .WithMany(p => p.PatologiaPacientes)
                .HasForeignKey(d => d.IdPatologia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatologiaPaciente_Patologia");

            //Complicacion Paciente
            modelBuilder.Entity<ComplicacionPaciente>()
            .HasKey(e => e.IdComplicacionPaciente);

            modelBuilder.Entity<ComplicacionPaciente>().ToTable("ComplicacionPaciente");

            modelBuilder.Entity<ComplicacionPaciente>().HasOne(c => c.Paciente)
                .WithMany(p => p.ComplicacionPacientes)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComplicacionPaciente_Paciente");

            modelBuilder.Entity<ComplicacionPaciente>().HasOne(c => c.Complicacion)
                .WithMany(p => p.ComplicacionPacientes)
                .HasForeignKey(d => d.IdComplicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComplicacionPaciente_Complicacion");

            //Receta Médica
            modelBuilder.Entity<RecetaMedica>()
            .HasKey(e => e.IdRecetaMedica);

            modelBuilder.Entity<RecetaMedica>().ToTable("RecetaMedica");

            modelBuilder.Entity<RecetaMedica>().HasOne(c => c.Medicamento)
               .WithMany(p => p.RecetaMedicas)
               .HasForeignKey(d => d.IdMedicamento)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_RecetaMedica_Medicamento");

            modelBuilder.Entity<RecetaMedica>().HasOne(c => c.HistorialClinico)
              .WithMany(p => p.RecetaMedicas)
              .HasForeignKey(d => d.IdHistorialClinico)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_RecetaMedica_HistorialClinico");

            //EspecialidadMedico
            modelBuilder.Entity<EspecialidadMedico>()
            .HasKey(e => e.IdEspecialidadMedico);

            modelBuilder.Entity<EspecialidadMedico>().ToTable("EspecialidadMedico");

            modelBuilder.Entity<EspecialidadMedico>().HasOne(c => c.Medico)
               .WithMany(p => p.EspecialidadMedicos)
               .HasForeignKey(d => d.IdMedico)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_EspecialidadMedico_Medico");

            modelBuilder.Entity<EspecialidadMedico>().HasOne(c => c.Especialidad)
               .WithMany(p => p.EspecialidadMedicos)
               .HasForeignKey(d => d.IdEspecialidad)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_EspecialidadMedico_Especialidad");

            //LugarAtencion
            modelBuilder.Entity<LugarAtencion>()
            .HasKey(e => e.IdLugarAtencion);

            modelBuilder.Entity<LugarAtencion>().ToTable("LugarAtencion");

            modelBuilder.Entity<LugarAtencion>().HasOne(c => c.Comuna)
               .WithMany(p => p.LugarAtenciones)
               .HasForeignKey(d => d.IdComuna)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_LugarAtencion_Comuna");

            //Módulo
            modelBuilder.Entity<Modulo>()
            .HasKey(e => e.IdModulo);

            modelBuilder.Entity<Modulo>().ToTable("Modulo");

            modelBuilder.Entity<Modulo>().HasOne(c => c.LugarAtencion)
               .WithMany(p => p.Modulos)
               .HasForeignKey(d => d.IdModulo)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Modulo_LugarAtencion");

            //PacienteDiabetico
            modelBuilder.Entity<PacienteDiabetico>()
            .HasKey(e => e.IdPacienteDiabetico);

            modelBuilder.Entity<PacienteDiabetico>().ToTable("PacienteDiabetico");

            modelBuilder.Entity<PacienteDiabetico>().HasOne(c => c.Paciente)
               .WithMany(p => p.PacienteDiabeticos)
               .HasForeignKey(d => d.IdPacienteDiabetico)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_PacienteDiabetico_Paciente");

            //PacienteAdultoMayor
            modelBuilder.Entity<PacienteAdultoMayor>()
            .HasKey(e => e.IdPacienteAdultoMayor);

            modelBuilder.Entity<PacienteAdultoMayor>().ToTable("PacienteAdultoMayor");

            modelBuilder.Entity<PacienteAdultoMayor>().HasOne(c => c.Paciente)
               .WithMany(p => p.PacienteAdultoMayors)
               .HasForeignKey(d => d.IdPacienteAdultoMayor)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_PacienteAdultoMayor_Paciente");

            //HistorialClinico
            modelBuilder.Entity<HistorialClinico>()
            .HasKey(e => e.IdHistorialClinico);

            modelBuilder.Entity<HistorialClinico>().ToTable("HistorialClinico");

            modelBuilder.Entity<HistorialClinico>().HasOne(c => c.Paciente)
               .WithMany(p => p.HistorialClinicos)
               .HasForeignKey(d => d.IdPaciente)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_HistorialClinico_Paciente");

            //Ficha Clinica Detalle 1 a 1
            modelBuilder.Entity<FichaClinicaDetalle>()
            .HasKey(e => e.IdFichaClinicaDetalle);

            modelBuilder.Entity<FichaClinicaDetalle>().ToTable("FichaClinicaDetalle");

            modelBuilder.Entity<FichaClinicaDetalle>().HasOne(c => c.FichaClinica)
               .WithMany(p => p.FichaClinicaDetalles)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasForeignKey(a => a.IdFichaClinica)
               .HasConstraintName("FK_FichaClinicaDetalle_FichaClinica");

            //Ficha Clinica
            modelBuilder.Entity<FichaClinica>()
            .HasKey(e => e.IdFichaClinica);

            modelBuilder.Entity<FichaClinica>().ToTable("FichaClinica");

            modelBuilder.Entity<FichaClinica>().HasOne(c => c.Paciente)
               .WithMany(p => p.FichaClinicas)
               .HasForeignKey(d => d.IdPaciente)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_FichaClinica_Paciente");

            modelBuilder.Entity<FichaClinica>().HasOne(c => c.Medico)
               .WithMany(p => p.FichaClinicas)
               .HasForeignKey(d => d.IdMedico)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_FichaClinica_Medico");

            modelBuilder.Entity<FichaClinica>().HasOne(c => c.Personal)
               .WithMany(p => p.FichaClinicas)
               .HasForeignKey(d => d.IdPersonal)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_FichaClinica_Personal");

            modelBuilder.Entity<FichaClinica>().HasOne(c => c.EstadoFichaClinica)
               .WithMany(p => p.FichaClinicas)
               .HasForeignKey(d => d.IdEstadoFichaClinica)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_FichaClinica_EstadoFichaClinica");

            modelBuilder.Entity<FichaClinica>().HasOne(c => c.Modulo)
               .WithMany(p => p.FichaClinicas)
               .HasForeignKey(d => d.IdModulo)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_FichaClinica_Modulo");
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
