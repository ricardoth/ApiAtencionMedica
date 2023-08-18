namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> entity)
        {
            entity
            .HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdPaciente");

            entity.ToTable("Paciente");

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

            entity.Property(e => e.Direccion)
               .HasMaxLength(200)
               .IsUnicode(false);

            entity.Property(e => e.Correo)
               .HasMaxLength(200)
               .IsUnicode(false);

            entity.Property(e => e.Telefono)
               .HasMaxLength(20)
               .IsUnicode(false);

            entity.Property(e => e.EstadoCivil)
               .HasMaxLength(20)
               .IsUnicode(false);

            entity.Property(e => e.Sexo)
               .HasMaxLength(20)
               .IsUnicode(false);

            entity.Property(e => e.FecCreacion)
               .HasColumnType("datetime")
               .IsUnicode(false);

            entity.Property(e => e.FecActualizacion)
                .HasColumnType("datetime")
                .IsUnicode(false);
        }
    }
}
