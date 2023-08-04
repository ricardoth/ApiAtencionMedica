namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class AgendaMedicoConfiguration : IEntityTypeConfiguration<AgendaMedico>
    {
        public void Configure(EntityTypeBuilder<AgendaMedico> entity)
        {
            entity.HasKey(e => e.IdAgendaMedico);

            entity.ToTable("AgendaMedico");

            entity.Property(e => e.FecInicio)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecFin)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecCreacion)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.FecActualizacion)
                .HasColumnType("datetime")
                .IsUnicode(false);

            entity.Property(e => e.HoraInicio)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.HoraFin)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(c => c.Medico)
                .WithMany(p => p.AgendaMedicos)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgendaMedico_Medico");

            entity.HasOne(c => c.EstadoAgendaMedico)
                .WithMany(p => p.AgendaMedicos)
                .HasForeignKey(d => d.IdEstadoAgendaMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgendaMedico_EstadoAgendaMedico");



        }
    }
}
