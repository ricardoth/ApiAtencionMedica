namespace AtencionMedica.Infraestructure.Repositories
{
    public class PacienteDiabeticoRepository : IPacienteDiabeticoRepository
    {
        private readonly AtencionMedicaContext _context;
        private IUnitOfWork _unitOfWork;

        public PacienteDiabeticoRepository(AtencionMedicaContext context, IUnitOfWork unitOfWork)
        {
            _context = context;        
            _unitOfWork = unitOfWork;
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
