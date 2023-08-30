namespace AtencionMedica.Infraestructure.Repositories
{
    public class PacienteDiabeticoRepository : IPacienteDiabeticoRepository
    {
        private readonly AtencionMedicaContext _context;

        public PacienteDiabeticoRepository(AtencionMedicaContext context)
        {
            _context = context;        
        }

        public async Task<ICollection<PacienteDiabetico>> GetAll()
        {
            return await _context.PacienteDiabeticos
                .Include(p => p.Paciente)
                .ToListAsync();
        }

        public async Task<PacienteDiabetico?> GetById(int id)
        {
            return await _context.PacienteDiabeticos
                .Include(p => p.Paciente)
                .Where(cp => cp.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
