namespace AtencionMedica.Infraestructure.Seeders
{
    public class SeedEstadoAgendaMedico : ISeed<EstadoAgendaMedico>
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            EstadoAgendaMedico[] hasData = {
                new EstadoAgendaMedico { Id = 1, NombreEstadoAgendaMedico = "Disponible", EsActivo = true },
                new EstadoAgendaMedico { Id = 2, NombreEstadoAgendaMedico = "Ocupado", EsActivo = true },
                new EstadoAgendaMedico { Id = 3, NombreEstadoAgendaMedico = "De Vacaciones", EsActivo = true },
                new EstadoAgendaMedico { Id = 4, NombreEstadoAgendaMedico = "Con Licencia Médica", EsActivo = true },
                new EstadoAgendaMedico { Id = 5, NombreEstadoAgendaMedico = "Medio Día Ocupado", EsActivo = true },
                
            };
            modelBuilder.Entity<EstadoAgendaMedico>().HasData(hasData);
        }
    }
}
