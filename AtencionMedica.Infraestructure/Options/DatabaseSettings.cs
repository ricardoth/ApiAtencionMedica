namespace AtencionMedica.Infraestructure.Options
{
    public class DatabaseSettings
    {
        public const string SettingName = "DatabaseSettings";
        public string ConnectionString { get; set; }
        public string DefaultSchema { get; set; }
        public bool? EnableSensitiveDataLogging { get; set; }
    }
}
