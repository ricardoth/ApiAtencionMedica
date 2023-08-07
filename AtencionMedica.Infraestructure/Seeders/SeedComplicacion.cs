namespace AtencionMedica.Infraestructure.Seeders
{
    public class SeedComplicacion : ISeed<Complicacion>
    {
        public void Seed(ModelBuilder modelBuilder)
        {

            Complicacion[] hasData = {
                new Complicacion { IdComplicacion = 1, NombreComplicacion = "Retinopatía", EsActivo = true},
                new Complicacion { IdComplicacion = 2, NombreComplicacion = "Ceguera", EsActivo = true},
                new Complicacion { IdComplicacion = 3, NombreComplicacion = "Insuficiencia Renal", EsActivo = true},
                new Complicacion { IdComplicacion = 4, NombreComplicacion = "Pie Diabético", EsActivo = true},
                new Complicacion { IdComplicacion = 5, NombreComplicacion = "Amputación", EsActivo = true},
                new Complicacion { IdComplicacion = 6, NombreComplicacion = "Hipertrofia Ventricular Izquerda", EsActivo = true},
                new Complicacion { IdComplicacion = 7, NombreComplicacion = "Enfermedad Cerebrovascular", EsActivo = true},
            };

            modelBuilder.Entity<Complicacion>().HasData(hasData);
        }
    }
}
