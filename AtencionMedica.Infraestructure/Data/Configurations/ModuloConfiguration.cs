namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class ModuloConfiguration : IEntityTypeConfiguration<Modulo>
    {
        public void Configure(EntityTypeBuilder<Modulo> entity)
        {
            entity
            .HasKey(e => e.IdModulo);

            entity.ToTable("Modulo");

            entity.Property(e => e.NombreModulo)
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false);

            entity.Property(e => e.Descripcion)
               .HasMaxLength(200)
               .IsUnicode(false);

            entity.HasOne(c => c.LugarAtencion)
               .WithMany(p => p.Modulos)
               .HasForeignKey(d => d.IdModulo)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Modulo_LugarAtencion");
        }
    }
}
