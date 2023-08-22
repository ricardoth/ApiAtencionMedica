namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class LugarAtencionConfiguration : IEntityTypeConfiguration<LugarAtencion>
    {
        public void Configure(EntityTypeBuilder<LugarAtencion> entity)
        {
            entity
            .HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdLugarAtencion");

            entity.ToTable("LugarAtencion");

            entity.Property(e => e.NombreLugar)
              .HasMaxLength(100)
              .IsRequired()
              .IsUnicode(false);

            entity.Property(e => e.Direccion)
              .HasMaxLength(200)
              .IsUnicode(false);

            entity.Property(e => e.Fono)
              .HasMaxLength(20)
              .IsUnicode(false);

            entity.Property(e => e.HorarioAtencion)
              .HasMaxLength(30)
              .IsUnicode(false);

            entity.HasOne(c => c.Comuna)
               .WithMany(p => p.LugarAtenciones)
               .HasForeignKey(d => d.IdComuna)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_LugarAtencion_Comuna");

        }
    }
}
