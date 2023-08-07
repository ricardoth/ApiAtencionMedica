namespace AtencionMedica.Infraestructure.Seeders
{
    internal class SeedLugarAtencion : ISeed<LugarAtencion>
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            LugarAtencion[] hasData = {
                new LugarAtencion { IdLugarAtencion = 1, IdComuna = 151, NombreLugar = "CIMEK Rancagua", Direccion = "Astorga 56", Fono = "(72) 2333900", HorarioAtencion = "09:00 - 20:00", EsActivo = true },
            };

            modelBuilder.Entity<LugarAtencion>().HasData(hasData);
        }
    }
}
