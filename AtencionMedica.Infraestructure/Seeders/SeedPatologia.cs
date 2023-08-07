namespace AtencionMedica.Infraestructure.Seeders
{
    internal class SeedPatologia : ISeed<Patologia>
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            Patologia[] hasData = { 
                new Patologia { Id = 1, NombrePatologia = "Diabetes Mellitus", EsActivo = true},
                new Patologia { Id = 2, NombrePatologia = "Hipertensión Arterial", EsActivo = true},
                new Patologia { Id = 3, NombrePatologia = "Epilepsia", EsActivo = true},
                new Patologia { Id = 4, NombrePatologia = "Artrosis Rodillas", EsActivo = true},
                new Patologia { Id = 5, NombrePatologia = "Artrosis Caderas", EsActivo = true},
                new Patologia { Id = 6, NombrePatologia = "Intolerancia a la Glucosa", EsActivo = true},
                new Patologia { Id = 7, NombrePatologia = "Parkinson", EsActivo = true},

            };

            modelBuilder.Entity<Patologia>().HasData(hasData);
        }
    }
}
