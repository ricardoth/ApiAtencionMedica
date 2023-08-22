namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class HistorialClinicoConfiguration : IEntityTypeConfiguration<HistorialClinico>
    {
        public void Configure(EntityTypeBuilder<HistorialClinico> entity)
        {
            entity
            .HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdHistorialClinico");

            entity.ToTable("HistorialClinico");

            entity.Property(e => e.Diagnostico)
               .HasMaxLength(500)
               .IsUnicode(false);

            entity.Property(e => e.Nota)
              .HasMaxLength(500)
              .IsUnicode(false);

            entity.Property(e => e.FechaHistorial)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecCreacion)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecActualizacion)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.HasOne(c => c.Paciente)
               .WithMany(p => p.HistorialClinicos)
               .HasForeignKey(d => d.IdPaciente)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_HistorialClinico_Paciente");
        }
    }
}
