namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class ComplicacionConfiguration : IEntityTypeConfiguration<Complicacion>
    {
        public void Configure(EntityTypeBuilder<Complicacion> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdComplicacion");

            entity.ToTable("Complicacion");

            entity.Property(e => e.NombreComplicacion)
               .HasMaxLength(100)
               .IsRequired()
               .IsUnicode(false);

        }
    }
}
