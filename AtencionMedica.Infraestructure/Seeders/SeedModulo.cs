﻿namespace AtencionMedica.Infraestructure.Seeders
{
    public class SeedModulo : ISeed<Modulo>
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            Modulo[] hasData = {
                new Modulo { IdModulo = 1, IdLugarAtencion = 1, NombreModulo = "Módulo Oftalmología", Descripcion = "Módulo para atenciones relacionadas con problemas oculares", EsActivo = true },
                new Modulo { IdModulo = 2, IdLugarAtencion = 1, NombreModulo = "Módulo Psicología", Descripcion = "Módulo para atenciones psicológicas", EsActivo = true },
                new Modulo { IdModulo = 3, IdLugarAtencion = 1, NombreModulo = "Módulo Urología", Descripcion = "Módulo para atenciones urologícas", EsActivo = true },
                new Modulo { IdModulo = 4, IdLugarAtencion = 1, NombreModulo = "Módulo Neurología", Descripcion = "Módulo para atenciones Neurológicas y problemas relacionados con el Cerebro", EsActivo = true },
                new Modulo { IdModulo = 5, IdLugarAtencion = 1, NombreModulo = "Módulo Pediatría", Descripcion = "Módulo para atenciones Neurológicas y problemas relacionados con el Cerebro", EsActivo = true },
                new Modulo { IdModulo = 6, IdLugarAtencion = 1, NombreModulo = "Módulo Nutrición", Descripcion = "Módulo para atenciones con el Nutricionista", EsActivo = true },
                new Modulo { IdModulo = 7, IdLugarAtencion = 1, NombreModulo = "Módulo Podología", Descripcion = "Módulo para atenciones de podología", EsActivo = true },
                new Modulo { IdModulo = 8, IdLugarAtencion = 1, NombreModulo = "Módulo Traumatología", Descripcion = "Módulo para atenciones traumatólogas", EsActivo = true },
                new Modulo { IdModulo = 9, IdLugarAtencion = 1, NombreModulo = "Módulo Reumatología", Descripcion = "Módulo para atenciones con el reumatológicas", EsActivo = true },
            };

            modelBuilder.Entity<Modulo>().HasData(hasData);

        }
    }
}
