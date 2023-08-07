using AtencionMedica.Infraestructure.Seeders.Interfaces;
using AtencionMedica.Infraestructure.Seeders;
using static AtencionMedica.Infraestructure.Seeders.Interfaces.ISeed;

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

            serviceCollection.AddTransient<IInitialize, SeedData>();

            serviceCollection.AddTransient<ISeed<Medicamento>, SeedMedicamento>();
        }
    }
}
