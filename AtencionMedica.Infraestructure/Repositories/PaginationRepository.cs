namespace AtencionMedica.Infraestructure.Repositories
{
    public class PaginationRepository<T> : IPaginationRepository<T> where T : class
    {
        private readonly AtencionMedicaContext _context;
        protected DbSet<T> _entities => _context.Set<T>();

        public PaginationRepository(AtencionMedicaContext context)
        {
            _context = context;
        }

        public async Task<ICollection<T>> GetAllPagination(int pageNumber, int pageSize)
        {
            return await _context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetAllTotalCount()
        {
            return await _context.Set<T>().CountAsync();
        }
    }
}
