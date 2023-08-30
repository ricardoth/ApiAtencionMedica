namespace AtencionMedica.Infraestructure.Repositories
{
    public class FichaClinicaDetalleRepository : IFichaClinicaDetalleRepository
    {
        private readonly AtencionMedicaContext _context;

        public FichaClinicaDetalleRepository(AtencionMedicaContext context)
        {
            _context = context;
        }

        public async Task<ICollection<FichaClinicaDetalle>> GetAll()
        {
            return await _context.FichaClinicaDetalles
                .Include(f => f.FichaClinica)
                .ToListAsync();
        }

        public async Task<FichaClinicaDetalle?> GetById(int id)
        {
            return await _context.FichaClinicaDetalles
                .Include(f => f.FichaClinica)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
