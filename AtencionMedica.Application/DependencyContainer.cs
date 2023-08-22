using System.Reflection;

namespace AtencionMedica.Application
{
    public static class DependencyContainer
    {
        public static void AddApplicationDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //Automapper
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #region Domain
            serviceCollection.AddTransient<IPatologiaService, PatologiaService>();
            serviceCollection.AddTransient<IComplicacionService, ComplicacionService>();
            serviceCollection.AddTransient<IEspecialidadService, EspecialidadService>();
            serviceCollection.AddTransient<IEstadoFichaClinicaService, EstadoFichaClinicaService>();
            serviceCollection.AddTransient<IEstadoAgendaMedicoService, EstadoAgendaMedicoService>();
            serviceCollection.AddTransient<IMedicamentoService, MedicamentoService>();
            serviceCollection.AddTransient<IComunaService, ComunaService>();    
            serviceCollection.AddTransient<IPacienteService, PacienteService>();
            serviceCollection.AddTransient<IComplicacionPacienteService, ComplicacionPacienteService>();
            #endregion
        }
    }
}
