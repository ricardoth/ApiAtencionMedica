namespace AtencionMedica.Infraestructure.Data.Configurations
{
    internal class PacienteDiabeticoConfiguration : IEntityTypeConfiguration<PacienteDiabetico>
    {
        public void Configure(EntityTypeBuilder<PacienteDiabetico> entity)
        {
            entity
                .HasKey(e => e.IdPacienteDiabetico);

            entity.ToTable("PacienteDiabetico");

            entity.HasOne(c => c.Paciente)
               .WithMany(p => p.PacienteDiabeticos)
               .HasForeignKey(d => d.IdPacienteDiabetico)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_PacienteDiabetico_Paciente");
        }
    }
}
