namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class RecetaMedicaConfiguration : IEntityTypeConfiguration<RecetaMedica>
    {
        public void Configure(EntityTypeBuilder<RecetaMedica> entity)
        {
            entity
            .HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdRecetaMedica");

            entity.ToTable("RecetaMedica");

            entity.Property(e => e.Cantidad)
             .IsUnicode(false);

            entity.Property(e => e.Instrucciones)
             .HasMaxLength(500)
             .IsUnicode(false);

            entity.Property(e => e.Observacion)
            .HasMaxLength(500)
            .IsUnicode(false);

            entity.Property(e => e.FecInicio)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecFin)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecCreacion)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecActualizacion)
                .HasColumnType("datetime")
                .IsUnicode(false);

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
