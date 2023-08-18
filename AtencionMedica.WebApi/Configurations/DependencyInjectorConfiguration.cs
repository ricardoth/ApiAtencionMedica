using System.Reflection;
using System.Text.Json.Serialization;

namespace AtencionMedica.WebApi.Configurations
{
    public static class DependencyInjectorConfiguration
    {
        public static void UseDependencyInjectorConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            #region Main Dependencies (don't touch)
            service.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
            #endregion


            #region Others Dependencies
            //service.AddAuthentication("BasicAuthentication")
            //    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            //service.Configure<BasicAuthCredentials>(configuration.GetSection("BasicAuthCredentials"));
            service.Configure<PaginationOptions>(configuration.GetSection("Pagination"));
            service.AddApplicationDependencies(configuration);
            service.AddDataAccess(configuration);
            #endregion
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
        }
    }
}
