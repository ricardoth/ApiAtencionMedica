﻿namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class EspecialidadConfiguration : IEntityTypeConfiguration<Especialidad>
    {
        public void Configure(EntityTypeBuilder<Especialidad> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdEspecialidad");

            entity.ToTable("Especialidad");

            entity.Property(e => e.NombreEspecialidad)
               .HasMaxLength(100)
               .IsRequired()
               .IsUnicode(false);
        }
    }
}
