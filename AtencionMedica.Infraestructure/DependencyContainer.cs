

namespace AtencionMedica.Infraestructure
{
    public static class DependencyContainer
    {
        public static void AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //DatabaseSettings databaseSettings = configuration.GetSection(DatabaseSettings.SettingName).Get<DatabaseSettings>();
            //serviceCollection.AddSingleton(databaseSettings);
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            serviceCollection.AddDbContext<AtencionMedicaContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("AtencionMedicaConnection")));

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>(); 

            //Seeders de BD Tablas Base
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

            #region Domain
            serviceCollection.AddTransient<IPatologiaService, PatologiaService>();
            serviceCollection.AddTransient<IComplicacionService, ComplicacionService>();
            #endregion
        }
    }
}
