namespace AtencionMedica.Infraestructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AtencionMedicaContext _context;    
        protected DbSet<T> _entities => _context.Set<T>();

        public BaseRepository(AtencionMedicaContext context)
        {
            _context = context;
        }

        public async Task Add(T entity) => await _context.Set<T>().AddAsync(entity);
        
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _context.Set<T>().Remove(entity);
        }

        public async Task<ICollection<T>> GetAll() => await _context.Set<T>().ToListAsync();
       
        public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);

        public void Update(T entity) => _context.Set<T>().Update(entity);
       
    }
}
