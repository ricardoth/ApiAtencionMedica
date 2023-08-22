namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class PatologiaPacienteConfiguration : IEntityTypeConfiguration<PatologiaPaciente>
    {
        public void Configure(EntityTypeBuilder<PatologiaPaciente> entity)
        {
            entity
            .HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdPatologiaPaciente");

            entity.ToTable("PatologiaPaciente");

            entity.Property(e => e.FecComplicacion)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecCreacion)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecActualizacion)
                .HasColumnType("datetime")
                .IsUnicode(false);

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
