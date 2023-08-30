namespace AtencionMedica.Infraestructure.Repositories
{
    public class HistorialClinicoRepository : IHistorialClinicoRepository
    {
        private readonly AtencionMedicaContext _context;
        public HistorialClinicoRepository(AtencionMedicaContext context) 
        {
            _context = context;
        }

        public async Task<ICollection<HistorialClinico>> GetAll()
        {
            return await _context.HistorialClinicos
                .Include(p => p.Paciente)
                .Include(r => r.RecetaMedicas)
                .ToListAsync();
        }

        public async Task<HistorialClinico?> GetById(int id)
        {
            return await _context.HistorialClinicos
                .Include(p => p.Paciente)
                .Include(r => r.RecetaMedicas)
                .Where(h => h.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
