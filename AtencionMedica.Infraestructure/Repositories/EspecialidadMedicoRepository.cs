namespace AtencionMedica.Infraestructure.Repositories
{
    public class EspecialidadMedicoRepository : IEspecialidadMedicoRepository
    {
        private readonly AtencionMedicaContext _context;

        public EspecialidadMedicoRepository(AtencionMedicaContext context)
        {
            _context = context;
        }

        public async Task<ICollection<EspecialidadMedico>> GetAll()
        {
            return await _context.EspecialidadMedicos
                .Include(e => e.Especialidad)
                .Include(m => m.Medico)
                .ToListAsync();
        }

        public async Task<EspecialidadMedico?> GetById(int id)
        {
            return await _context.EspecialidadMedicos
                .Include(e => e.Especialidad)
                .Include(m => m.Medico)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
