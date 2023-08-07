namespace AtencionMedica.Infraestructure.Seeders
{
    public class SeedEstadoFichaClinica : ISeed<EstadoFichaClinica>
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            EstadoFichaClinica[] hasData = {
                new EstadoFichaClinica { Id = 1, NombreEstadoFichaClinica = "En Proceso", EsActivo = true },
                new EstadoFichaClinica { Id = 2, NombreEstadoFichaClinica = "Completado", EsActivo = true },
                new EstadoFichaClinica { Id = 3, NombreEstadoFichaClinica = "Cancelado", EsActivo = true },
                new EstadoFichaClinica { Id = 4, NombreEstadoFichaClinica = "En Revisión", EsActivo = true },
                new EstadoFichaClinica { Id = 5, NombreEstadoFichaClinica = "Aprobado", EsActivo = true },
                new EstadoFichaClinica { Id = 6, NombreEstadoFichaClinica = "Pendiente", EsActivo = true },
                new EstadoFichaClinica { Id = 7, NombreEstadoFichaClinica = "Rechazado", EsActivo = true },
                new EstadoFichaClinica { Id = 8, NombreEstadoFichaClinica = "Cerrado", EsActivo = true },
                new EstadoFichaClinica { Id = 9, NombreEstadoFichaClinica = "Archivado", EsActivo = true },
            };

            modelBuilder.Entity<EstadoFichaClinica>().HasData(hasData);
        }
    }
}
