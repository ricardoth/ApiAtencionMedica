namespace AtencionMedica.Infraestructure.Repositories
{
    public class AgendaMedicoRepository : IAgendaMedicoRepository
    {
        private readonly AtencionMedicaContext _context;

        public AgendaMedicoRepository(AtencionMedicaContext context)
        {
            _context = context;       
        }

        public async Task<ICollection<AgendaMedico>> GetAll()
        {
            return await _context.AgendaMedicos
                .Include(m => m.Medico)
                .Include(e => e.EstadoAgendaMedico)
                .ToListAsync();
        }

        public async Task<AgendaMedico?> GetById(int id)
        {
            return await _context.AgendaMedicos
                .Include(m => m.Medico)
                .Include(e => e.EstadoAgendaMedico)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
