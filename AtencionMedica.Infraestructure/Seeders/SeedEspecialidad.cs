namespace AtencionMedica.Infraestructure.Seeders
{
    public class SeedEspecialidad : ISeed<Especialidad>
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            Especialidad[] hasData = {
                new Especialidad { Id = 1, NombreEspecialidad = "Oftalmología", EsActivo = true },
                new Especialidad { Id = 2, NombreEspecialidad = "Nutrición", EsActivo = true },
                new Especialidad { Id = 3, NombreEspecialidad = "Trumatología", EsActivo = true },
                new Especialidad { Id = 4, NombreEspecialidad = "Psicología", EsActivo = true },
                new Especialidad { Id = 5, NombreEspecialidad = "Urología", EsActivo = true },
                new Especialidad { Id = 6, NombreEspecialidad = "Pediatría", EsActivo = true },
                new Especialidad { Id = 7, NombreEspecialidad = "Podología", EsActivo = true },
                new Especialidad { Id = 8, NombreEspecialidad = "Reumatología", EsActivo = true },
                new Especialidad { Id = 9, NombreEspecialidad = "Neurología", EsActivo = true },
            };

            modelBuilder.Entity<Especialidad>().HasData(hasData);
        }
    }
}
