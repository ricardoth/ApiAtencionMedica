namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class LugarAtencionConfiguration : IEntityTypeConfiguration<LugarAtencion>
    {
        public void Configure(EntityTypeBuilder<LugarAtencion> entity)
        {
            entity
            .HasKey(e => e.IdLugarAtencion);

            entity.ToTable("LugarAtencion");

            entity.HasOne(c => c.Comuna)
               .WithMany(p => p.LugarAtenciones)
               .HasForeignKey(d => d.IdComuna)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_LugarAtencion_Comuna");

        }
    }
}
