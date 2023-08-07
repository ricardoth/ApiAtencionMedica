namespace AtencionMedica.Infraestructure.Seeders
{
    public class SeedEstadoFichaClinica : ISeed<EstadoFichaClinica>
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            EstadoFichaClinica[] hasData = {
                new EstadoFichaClinica { IdEstadoFichaClinica = 1, NombreEstadoFichaClinica = "En Proceso", EsActivo = true },
                new EstadoFichaClinica { IdEstadoFichaClinica = 2, NombreEstadoFichaClinica = "Completado", EsActivo = true },
                new EstadoFichaClinica { IdEstadoFichaClinica = 3, NombreEstadoFichaClinica = "Cancelado", EsActivo = true },
                new EstadoFichaClinica { IdEstadoFichaClinica = 4, NombreEstadoFichaClinica = "En Revisión", EsActivo = true },
                new EstadoFichaClinica { IdEstadoFichaClinica = 5, NombreEstadoFichaClinica = "Aprobado", EsActivo = true },
                new EstadoFichaClinica { IdEstadoFichaClinica = 6, NombreEstadoFichaClinica = "Pendiente", EsActivo = true },
                new EstadoFichaClinica { IdEstadoFichaClinica = 7, NombreEstadoFichaClinica = "Rechazado", EsActivo = true },
                new EstadoFichaClinica { IdEstadoFichaClinica = 8, NombreEstadoFichaClinica = "Cerrado", EsActivo = true },
                new EstadoFichaClinica { IdEstadoFichaClinica = 9, NombreEstadoFichaClinica = "Archivado", EsActivo = true },
            };

            modelBuilder.Entity<EstadoFichaClinica>().HasData(hasData);
        }
    }
}
