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

        public async Task Add(PacienteAdultoMayor entity)
        {
            entity.FecCreacion = DateTime.Now;
            await _context.PacienteAdultoMayores.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(PacienteAdultoMayor entity)
        {
            entity.FecActualizacion = DateTime.Now;
            _context.PacienteAdultoMayores.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity is null)
                return false;

            entity.EsActivo = false;
            entity.FecActualizacion = DateTime.Now;
            _context.PacienteAdultoMayores.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
