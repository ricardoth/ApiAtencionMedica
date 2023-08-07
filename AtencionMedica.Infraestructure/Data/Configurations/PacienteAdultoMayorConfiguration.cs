using Microsoft.EntityFrameworkCore;

namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class PacienteAdultoMayorConfiguration : IEntityTypeConfiguration<PacienteAdultoMayor>
    {
        public void Configure(EntityTypeBuilder<PacienteAdultoMayor> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdPacienteAdultoMayor");

            entity.ToTable("PacienteAdultoMayor");

            entity.HasOne(c => c.Paciente)
               .WithMany(p => p.PacienteAdultoMayors)
               .HasForeignKey(d => d.Id)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_PacienteAdultoMayor_Paciente");
        }
    }
}
