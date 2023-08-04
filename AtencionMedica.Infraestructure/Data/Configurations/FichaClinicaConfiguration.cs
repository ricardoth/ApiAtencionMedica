namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class FichaClinicaConfiguration : IEntityTypeConfiguration<FichaClinica>
    {
        public void Configure(EntityTypeBuilder<FichaClinica> entity)
        {
            entity
            .HasKey(e => e.IdFichaClinica);

            entity.ToTable("FichaClinica");

            entity.Property(e => e.FechaAtencion)
               .IsRequired()
               .HasColumnType("datetime")
               .IsUnicode(false);

            entity.Property(e => e.FecCreacion)
               .HasColumnType("datetime")
               .IsUnicode(false);

            entity.Property(e => e.FecActualizacion)
               .HasColumnType("datetime")
               .IsUnicode(false);

            entity.HasOne(c => c.Paciente)
               .WithMany(p => p.FichaClinicas)
               .HasForeignKey(d => d.IdPaciente)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_FichaClinica_Paciente");

            entity.HasOne(c => c.Medico)
               .WithMany(p => p.FichaClinicas)
               .HasForeignKey(d => d.IdMedico)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_FichaClinica_Medico");

            entity.HasOne(c => c.Personal)
               .WithMany(p => p.FichaClinicas)
               .HasForeignKey(d => d.IdPersonal)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_FichaClinica_Personal");

            entity.HasOne(c => c.EstadoFichaClinica)
               .WithMany(p => p.FichaClinicas)
               .HasForeignKey(d => d.IdEstadoFichaClinica)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_FichaClinica_EstadoFichaClinica");

            entity.HasOne(c => c.Modulo)
               .WithMany(p => p.FichaClinicas)
               .HasForeignKey(d => d.IdModulo)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_FichaClinica_Modulo");
        }
    }
}
