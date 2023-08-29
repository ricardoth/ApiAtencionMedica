namespace AtencionMedica.Infraestructure.Repositories
{
    public class PacienteAdultoMayorRepository : IPacienteAdultoMayorRepository
    {
        private readonly AtencionMedicaContext _context;
        private IUnitOfWork _unitOfWork;

        public PacienteAdultoMayorRepository(AtencionMedicaContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<PacienteAdultoMayor>> GetAll()
        {
            return await _context.PacienteAdultoMayores
                 .Include(p => p.Paciente)
                 .ToListAsync();
        }

        public async Task<PacienteAdultoMayor?> GetById(int id)
        {
            return await _context.PacienteAdultoMayores
                .Include(p => p.Paciente)
                .Where(cp => cp.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
