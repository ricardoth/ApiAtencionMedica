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
        }
    }
}
