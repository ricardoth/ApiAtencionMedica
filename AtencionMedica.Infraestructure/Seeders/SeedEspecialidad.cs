namespace AtencionMedica.Infraestructure.Seeders
{
    public class SeedEspecialidad : ISeed<Especialidad>
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            Especialidad[] hasData = {
                new Especialidad { IdEspecialidad = 1, NombreEspecialidad = "Oftalmología", EsActivo = true },
                new Especialidad { IdEspecialidad = 2, NombreEspecialidad = "Nutrición", EsActivo = true },
                new Especialidad { IdEspecialidad = 3, NombreEspecialidad = "Trumatología", EsActivo = true },
                new Especialidad { IdEspecialidad = 4, NombreEspecialidad = "Psicología", EsActivo = true },
                new Especialidad { IdEspecialidad = 5, NombreEspecialidad = "Urología", EsActivo = true },
                new Especialidad { IdEspecialidad = 6, NombreEspecialidad = "Pediatría", EsActivo = true },
                new Especialidad { IdEspecialidad = 7, NombreEspecialidad = "Podología", EsActivo = true },
                new Especialidad { IdEspecialidad = 8, NombreEspecialidad = "Reumatología", EsActivo = true },
                new Especialidad { IdEspecialidad = 9, NombreEspecialidad = "Neurología", EsActivo = true },
            };

            modelBuilder.Entity<Especialidad>().HasData(hasData);
        }
    }
}
