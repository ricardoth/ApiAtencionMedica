﻿namespace AtencionMedica.Infraestructure
{
    public static class DependencyContainer
    {
        public static void AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //DatabaseSettings databaseSettings = configuration.GetSection(DatabaseSettings.SettingName).Get<DatabaseSettings>();
            //serviceCollection.AddSingleton(databaseSettings);
            serviceCollection.AddDbContext<AtencionMedicaContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("AtencionMedicaConnection")));

            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>(); 

            serviceCollection.AddTransient<IInitialize, SeedData>();

            serviceCollection.AddTransient<ISeed<Complicacion>, SeedComplicacion>();
            serviceCollection.AddTransient<ISeed<Comuna>, SeedComuna>();
            serviceCollection.AddTransient<ISeed<Especialidad>, SeedEspecialidad>();
            serviceCollection.AddTransient<ISeed<EstadoAgendaMedico>, SeedEstadoAgendaMedico>();
            serviceCollection.AddTransient<ISeed<EstadoFichaClinica>, SeedEstadoFichaClinica>();
            serviceCollection.AddTransient<ISeed<LugarAtencion>, SeedLugarAtencion>();
            serviceCollection.AddTransient<ISeed<Medicamento>, SeedMedicamento>();
            serviceCollection.AddTransient<ISeed<Modulo>, SeedModulo>();
            serviceCollection.AddTransient<ISeed<Patologia>, SeedPatologia>();
        }
    }
}
