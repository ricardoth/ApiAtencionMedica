namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdMedico");

            entity.ToTable("Medico");

            entity.Property(e => e.Rut)
               .IsRequired()
               .IsUnicode(false);

            entity.Property(e => e.Dv)
               .HasMaxLength(2)
               .IsRequired()
               .IsUnicode(false);

            entity.Property(e => e.Nombres)
               .HasMaxLength(200)
               .IsRequired()
               .IsUnicode(false);

            entity.Property(e => e.ApellidoPaterno)
               .HasMaxLength(200)
               .IsRequired()
               .IsUnicode(false);

            entity.Property(e => e.ApellidoMaterno)
               .HasMaxLength(200)
               .IsUnicode(false);

            entity.Property(e => e.Correo)
               .HasMaxLength(200)
               .IsUnicode(false);

            entity.Property(e => e.Telefono)
               .HasMaxLength(20)
               .IsUnicode(false);

        }
    }
}
