namespace AtencionMedica.Infraestructure.Data.Configurations
{
    internal class PacienteDiabeticoConfiguration : IEntityTypeConfiguration<PacienteDiabetico>
    {
        public void Configure(EntityTypeBuilder<PacienteDiabetico> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdPacienteDiabetico");

            entity.ToTable("PacienteDiabetico");

            entity.Property(e => e.FecAmputacion)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecEvaluacionDiabetes)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecNeuropatia)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecRetinopatia)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.HasOne(c => c.Paciente)
               .WithMany(p => p.PacienteDiabeticos)
               .HasForeignKey(d => d.IdPaciente)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_PacienteDiabetico_Paciente");
        }
    }
}
