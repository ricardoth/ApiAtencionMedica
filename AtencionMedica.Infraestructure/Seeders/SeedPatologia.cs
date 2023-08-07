namespace AtencionMedica.Infraestructure.Seeders
{
    internal class SeedPatologia : ISeed<Patologia>
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            Patologia[] hasData = { 
                new Patologia { IdPatologia = 1, NombrePatologia = "Diabetes Mellitus", EsActivo = true},
                new Patologia { IdPatologia = 2, NombrePatologia = "Hipertensión Arterial", EsActivo = true},
                new Patologia { IdPatologia = 3, NombrePatologia = "Epilepsia", EsActivo = true},
                new Patologia { IdPatologia = 4, NombrePatologia = "Artrosis Rodillas", EsActivo = true},
                new Patologia { IdPatologia = 5, NombrePatologia = "Artrosis Caderas", EsActivo = true},
                new Patologia { IdPatologia = 6, NombrePatologia = "Intolerancia a la Glucosa", EsActivo = true},
                new Patologia { IdPatologia = 7, NombrePatologia = "Parkinson", EsActivo = true},

            };

            modelBuilder.Entity<Patologia>().HasData(hasData);
        }
    }
}
