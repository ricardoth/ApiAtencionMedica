namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class FichaClinicaDetalleConfiguration : IEntityTypeConfiguration<FichaClinicaDetalle>
    {
        public void Configure(EntityTypeBuilder<FichaClinicaDetalle> entity)
        {
            entity
            .HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdFichaClinicaDetalle");

            entity.ToTable("FichaClinicaDetalle");

            entity.Property(e => e.AgudezaVisual)
               .IsUnicode(false);

            entity.Property(e => e.PresionIntraocular)
               .IsUnicode(false);

            entity.Property(e => e.FondoDeOjo)
               .IsUnicode(false);

            entity.Property(e => e.Observacion)
               .HasMaxLength(500)
               .IsUnicode(false);

            entity.Property(e => e.FecCreacion)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecActualizacion)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.HasOne(c => c.FichaClinica)
               .WithMany(p => p.FichaClinicaDetalles)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasForeignKey(a => a.IdFichaClinica)
               .HasConstraintName("FK_FichaClinicaDetalle_FichaClinica");
        }
    }
}
