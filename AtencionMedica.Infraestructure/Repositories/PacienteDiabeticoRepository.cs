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

        public async Task Add(PacienteDiabetico entity)
        {
            await _context.PacienteDiabeticos.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PacienteDiabetico entity)
        {
            entity.FecActualizacion = DateTime.UtcNow;
            _context.PacienteDiabeticos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity is null)
                return false;

            entity.EsActivo = false;
            entity.FecActualizacion = DateTime.UtcNow;
            _context.PacienteDiabeticos.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
