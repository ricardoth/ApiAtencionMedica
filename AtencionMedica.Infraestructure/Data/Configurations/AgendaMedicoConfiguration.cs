using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class AgendaMedicoConfiguration : IEntityTypeConfiguration<AgendaMedico>
    {
        public void Configure(EntityTypeBuilder<AgendaMedico> entity)
        {
            entity.HasKey(e => e.IdAgendaMedico);

            entity.ToTable("AgendaMedico");

            //entity.HasMany(c => c.EstadoAgendaMedicos)
            //    .WithOne()
                

           


        }
    }
}
