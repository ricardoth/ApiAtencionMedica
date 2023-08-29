namespace AtencionMedica.Infraestructure.Repositories
{
    public class LugarAtencionRepository : ILugarAtencionRepository
    {
        private readonly AtencionMedicaContext _context;

        public LugarAtencionRepository(AtencionMedicaContext context)
        {
            _context = context;       
        }

        public async Task<ICollection<LugarAtencion>> GetAll()
        {
            return await _context.LugarAtenciones
                .Include(c => c.Comuna)
                .ToListAsync();
        }

        public async Task<LugarAtencion?> GetById(int id)
        {
            return await _context.LugarAtenciones
                .Include(c => c.Comuna)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
