﻿namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class EstadoAgendaMedicoConfiguration : IEntityTypeConfiguration<EstadoAgendaMedico>
    {
        public void Configure(EntityTypeBuilder<EstadoAgendaMedico> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdEstadoAgendaMedico");

            entity.ToTable("EstadoAgendaMedico");

            entity.Property(e => e.NombreEstadoAgendaMedico)
               .HasMaxLength(50)
               .IsRequired()
               .IsUnicode(false);

        }
    }
}
