namespace AtencionMedica.Infraestructure.Repositories
{
    public class PacientePaginationRepository : IPacientePaginationRepository
    {
        private readonly AtencionMedicaContext _context;
        public PacientePaginationRepository(AtencionMedicaContext context) 
        {
            _context = context;
        }

        public async Task<ICollection<Paciente>> GetPacientesPagination(int pageNumber, int pageSize)
        {
            return await _context.Pacientes.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetTotalPacientesCount()
        {
            return await _context.Pacientes.CountAsync();
        }
    }
}
