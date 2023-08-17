namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class ComunaConfiguration : IEntityTypeConfiguration<Comuna>
    {
        public void Configure(EntityTypeBuilder<Comuna> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdComuna");

            entity.ToTable("Comuna");

            entity.Property(e => e.NombreComuna)
               .HasMaxLength(100)
               .IsRequired()
               .IsUnicode(false);

            entity.Property(e => e.Region)
               .HasMaxLength(150)
               .IsUnicode(false);

            entity.Property(e => e.SiglaRegion)
               .HasMaxLength(10)
               .IsUnicode(false);
        }
    }
}
