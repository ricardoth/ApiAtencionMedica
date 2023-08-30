namespace AtencionMedica.Infraestructure.Repositories
{
    public class FichaClinicaRepository : IFichaClinicaRepository
    {
        private readonly AtencionMedicaContext _context;

        public FichaClinicaRepository(AtencionMedicaContext context)
        {
            _context = context;
        }

        public async Task<ICollection<FichaClinica>> GetAll()
        {
            return await _context.FichaClinicas
                .Include(e => e.EstadoFichaClinica)
                .Include(p => p.Paciente)
                .Include(m => m.Medico)
                .Include(p => p.Personal)
                .Include(m => m.Modulo)
                .Include(a => a.FichaClinicaDetalles)
                .ToListAsync();
        }

        public async Task<FichaClinica?> GetById(int id)
        {
            return await _context.FichaClinicas
                .Include(e => e.EstadoFichaClinica)
                .Include(p => p.Paciente)
                .Include(m => m.Medico)
                .Include(p => p.Personal)
                .Include(m => m.Modulo)
                .Include(a => a.FichaClinicaDetalles)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
