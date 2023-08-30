namespace AtencionMedica.Infraestructure.Repositories
{
    public class ComplicacionPacienteRepository : IComplicacionPacienteRepository
    {
        private readonly AtencionMedicaContext _context;

        public ComplicacionPacienteRepository(AtencionMedicaContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ComplicacionPaciente>> GetAll()
        {
            return await _context.ComplicacionPacientes
                .Include(p => p.Paciente)
                .Include(c => c.Complicacion)
                .ToListAsync();
        }

        public async Task<ComplicacionPaciente?> GetById(int id)
        {
            return await _context.ComplicacionPacientes
                .Include(p => p.Paciente)
                .Include(c => c.Complicacion)
                .Where(cp => cp.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
