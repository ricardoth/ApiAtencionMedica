namespace AtencionMedica.Infraestructure.Seeders
{
    public class SeedData : IInitialize
    {
        private readonly IList<IGenericSeed> seeds;

        public SeedData(
            ISeed<Complicacion> seedComplicacion,
            ISeed<Comuna> seedComuna,
            ISeed<Especialidad> seedEspecialidad,
            ISeed<EstadoAgendaMedico> seedEstadoAgendaMedico,
            ISeed<EstadoFichaClinica> seedEstadoFichaClinica,
            ISeed<Medicamento> seedMedicamento,
            ISeed<Patologia> seedPatologia)
        {
            seeds = new List<IGenericSeed>
            {
                seedComplicacion,
                seedComuna,
                seedEspecialidad,
                seedEstadoAgendaMedico, 
                seedEstadoFichaClinica,
                seedMedicamento,
                seedPatologia,
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
