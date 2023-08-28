namespace AtencionMedica.Infraestructure
{
    public static class DependencyContainer
    {
        public static void AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //DatabaseSettings databaseSettings = configuration.GetSection(DatabaseSettings.SettingName).Get<DatabaseSettings>();
            //serviceCollection.AddSingleton(databaseSettings);
   
            serviceCollection.AddDbContext<AtencionMedicaContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("AtencionMedicaConnection")));

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(IPaginationRepository<>), typeof(PaginationRepository<>));
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>(); 

            //Other Repositorys With Dependencies
            serviceCollection.AddTransient<IComplicacionPacienteRepository, ComplicacionPacienteRepository>();
            serviceCollection.AddTransient<IPacienteDiabeticoRepository, PacienteDiabeticoRepository>();
            serviceCollection.AddTransient<IPacienteAdultoMayorRepository, PacienteAdultoMayorRepository>();


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
        }
    }
}
