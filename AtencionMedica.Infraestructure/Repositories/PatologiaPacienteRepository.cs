namespace AtencionMedica.Infraestructure.Repositories
{
    public class PatologiaPacienteRepository : IPatologiaPacienteRepository
    {
        private readonly AtencionMedicaContext _context;

        public PatologiaPacienteRepository(AtencionMedicaContext context)
        {
            _context = context;
        }

        public async Task<ICollection<PatologiaPaciente>> GetAll()
        {
            return await _context.PatologiaPacientes
                .Include(p => p.Paciente)
                .Include(p => p.Patologia)
                .ToListAsync();
        }

        public async Task<PatologiaPaciente?> GetById(int id)
        {
            return await _context.PatologiaPacientes
                .Include(p => p.Paciente)
                .Include(p => p.Patologia)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
