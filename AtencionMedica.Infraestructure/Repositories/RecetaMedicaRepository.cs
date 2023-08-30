namespace AtencionMedica.Infraestructure.Repositories
{
    public class RecetaMedicaRepository : IRecetaMedicaRepository
    {
        private readonly AtencionMedicaContext _context;

        public RecetaMedicaRepository(AtencionMedicaContext context)
        {
            _context = context;
        }

        public async Task<ICollection<RecetaMedica>> GetAll()
        {
            return await _context.RecetaMedicas
                .Include(h => h.HistorialClinico)
                .Include(m => m.Medicamento)
                .ToListAsync();
        }

        public async Task<RecetaMedica?> GetById(int id)
        {
            return await _context.RecetaMedicas
                .Include(h => h.HistorialClinico)
                .Include(m => m.Medicamento)
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
