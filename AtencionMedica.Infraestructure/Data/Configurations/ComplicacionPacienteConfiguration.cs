namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class ComplicacionPacienteConfiguration : IEntityTypeConfiguration<ComplicacionPaciente>
    {
        public void Configure(EntityTypeBuilder<ComplicacionPaciente> entity)
        {
            entity
            .HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdComplicacionPaciente");

            entity.ToTable("ComplicacionPaciente");

            entity.Property(e => e.FecComplicacion)
                .IsRequired()
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.HasOne(c => c.Paciente)
                .WithMany(p => p.ComplicacionPacientes)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComplicacionPaciente_Paciente");

            entity.HasOne(c => c.Complicacion)
                .WithMany(p => p.ComplicacionPacientes)
                .HasForeignKey(d => d.IdComplicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComplicacionPaciente_Complicacion");
        }
    }
}
