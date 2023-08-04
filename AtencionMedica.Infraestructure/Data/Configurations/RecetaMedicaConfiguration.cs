namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class RecetaMedicaConfiguration : IEntityTypeConfiguration<RecetaMedica>
    {
        public void Configure(EntityTypeBuilder<RecetaMedica> entity)
        {
            entity
            .HasKey(e => e.IdRecetaMedica);

            entity.ToTable("RecetaMedica");

            entity.HasOne(c => c.Medicamento)
               .WithMany(p => p.RecetaMedicas)
               .HasForeignKey(d => d.IdMedicamento)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_RecetaMedica_Medicamento");

            entity.HasOne(c => c.HistorialClinico)
              .WithMany(p => p.RecetaMedicas)
              .HasForeignKey(d => d.IdHistorialClinico)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_RecetaMedica_HistorialClinico");
        }
    }
}
