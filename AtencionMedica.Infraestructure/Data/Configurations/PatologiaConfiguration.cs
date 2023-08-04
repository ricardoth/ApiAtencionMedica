namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class PatologiaConfiguration : IEntityTypeConfiguration<Patologia>
    {
        public void Configure(EntityTypeBuilder<Patologia> entity)
        {
            entity
            .HasKey(e => e.IdPatologia);

            entity.ToTable("Patologia");

            entity.Property(e => e.NombrePatologia)
               .HasMaxLength(150)
               .IsRequired()
               .IsUnicode(false);
        }
    }
}
