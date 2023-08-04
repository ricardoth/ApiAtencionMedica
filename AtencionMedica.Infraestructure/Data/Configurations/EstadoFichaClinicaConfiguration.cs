namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class EstadoFichaClinicaConfiguration : IEntityTypeConfiguration<EstadoFichaClinica>
    {
        public void Configure(EntityTypeBuilder<EstadoFichaClinica> entity)
        {
            entity
            .HasKey(e => e.IdEstadoFichaClinica);

            entity.ToTable("EstadoFichaClinica");

            entity.Property(e => e.NombreEstadoFichaClinica)
               .HasMaxLength(50)
               .IsRequired()
               .IsUnicode(false);
        }
    }
}
