namespace AtencionMedica.Application
{
    public static class DependencyContainer
    {
        public static void AddApplicationDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //Automapper
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #region Domain
            serviceCollection.AddTransient<IPatologiaService, PatologiaService>();
            serviceCollection.AddTransient<IComplicacionService, ComplicacionService>();
            #endregion
        }
    }
}
