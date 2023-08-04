namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class PatologiaPacienteConfiguration : IEntityTypeConfiguration<PatologiaPaciente>
    {
        public void Configure(EntityTypeBuilder<PatologiaPaciente> entity)
        {
            entity
            .HasKey(e => e.IdPatologiaPaciente);

            entity.ToTable("PatologiaPaciente");

            entity.HasOne(c => c.Paciente)
                .WithMany(p => p.PatologiaPacientes)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatologiaPaciente_Paciente");

            entity.HasOne(c => c.Patologia)
                .WithMany(p => p.PatologiaPacientes)
                .HasForeignKey(d => d.IdPatologia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatologiaPaciente_Patologia");
        }
    }
}
