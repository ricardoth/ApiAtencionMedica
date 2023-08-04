namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class EspecialidadMedicoConfiguration : IEntityTypeConfiguration<EspecialidadMedico>
    {
        public void Configure(EntityTypeBuilder<EspecialidadMedico> entity)
        {
            entity
            .HasKey(e => e.IdEspecialidadMedico);

            entity.ToTable("EspecialidadMedico");

            entity.HasOne(c => c.Medico)
               .WithMany(p => p.EspecialidadMedicos)
               .HasForeignKey(d => d.IdMedico)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_EspecialidadMedico_Medico");

            entity.Property(e => e.CasaEstudio)
               .HasMaxLength(200)
               .IsUnicode(false);

            entity.Property(e => e.FechaObtencionEspecialidad)
              .HasColumnType("datetime")
              .IsUnicode(false);

            entity.HasOne(c => c.Especialidad)
               .WithMany(p => p.EspecialidadMedicos)
               .HasForeignKey(d => d.IdEspecialidad)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_EspecialidadMedico_Especialidad");
        }
    }
}
