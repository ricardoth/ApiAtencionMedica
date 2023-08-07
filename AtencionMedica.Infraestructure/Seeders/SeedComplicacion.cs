namespace AtencionMedica.Infraestructure.Seeders
{
    public class SeedComplicacion : ISeed<Complicacion>
    {
        public void Seed(ModelBuilder modelBuilder)
        {

            Complicacion[] hasData = {
                new Complicacion { Id = 1, NombreComplicacion = "Retinopatía", EsActivo = true},
                new Complicacion { Id = 2, NombreComplicacion = "Ceguera", EsActivo = true},
                new Complicacion { Id = 3, NombreComplicacion = "Insuficiencia Renal", EsActivo = true},
                new Complicacion { Id = 4, NombreComplicacion = "Pie Diabético", EsActivo = true},
                new Complicacion { Id = 5, NombreComplicacion = "Amputación", EsActivo = true},
                new Complicacion { Id = 6, NombreComplicacion = "Hipertrofia Ventricular Izquerda", EsActivo = true},
                new Complicacion { Id = 7, NombreComplicacion = "Enfermedad Cerebrovascular", EsActivo = true},
            };

            modelBuilder.Entity<Complicacion>().HasData(hasData);
        }
    }
}
