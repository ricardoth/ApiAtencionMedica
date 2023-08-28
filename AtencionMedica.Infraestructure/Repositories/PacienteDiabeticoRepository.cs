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

        public async Task Add(PacienteDiabetico entity)
        {
            entity.FecCreacion = DateTime.Now;
            await _context.PacienteDiabeticos.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(PacienteDiabetico entity)
        {
            entity.FecActualizacion = DateTime.Now;
            _context.PacienteDiabeticos.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity is null)
                return false;

            entity.EsActivo = false;
            entity.FecActualizacion = DateTime.Now;
            _context.PacienteDiabeticos.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
