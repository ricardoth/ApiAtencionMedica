namespace AtencionMedica.Infraestructure.Repositories
{
    public class ModuloRepository : IModuloRepository
    {
        private readonly AtencionMedicaContext _context;

        public ModuloRepository(AtencionMedicaContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Modulo>> GetAll()
        {
            return await _context.Modulos
                .Include(l => l.LugarAtencion)
                .ThenInclude(c => c.Comuna)
                .ToListAsync();
        }

        public async Task<Modulo?> GetById(int id)
        {
            return await _context.Modulos
                .Include(l => l.LugarAtencion)
                .ThenInclude(c => c.Comuna)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
