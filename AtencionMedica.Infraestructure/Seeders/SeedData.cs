namespace AtencionMedica.Infraestructure.Seeders
{
    public class SeedData : IInitialize
    {
        private readonly IList<IGenericSeed> seeds;

        public SeedData(
            ISeed<Comuna> seedComuna,
            ISeed<EstadoAgendaMedico> seedEstadoAgendaMedico,
            ISeed<EstadoFichaClinica> seedEstadoFichaClinica)
        {
            seeds = new List<IGenericSeed>
            {
                seedComuna,
                seedEstadoAgendaMedico, 
                seedEstadoFichaClinica,
            };
        }
        public void Initialize(ModelBuilder modelBuilder)
        {
            foreach (IGenericSeed seed in seeds) 
            {
                seed.Seed(modelBuilder);
            }
        }
    }
}
