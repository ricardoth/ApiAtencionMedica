namespace AtencionMedica.Infraestructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AtencionMedicaContext _context;    
        protected readonly DbSet<T> _entities;

        public BaseRepository(AtencionMedicaContext context)
        {
            _context = context;
            _entities = context.Set<T>();   
        }

        public async Task Add(T entity) => await _entities.AddAsync(entity);
        
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }

        public async Task<ICollection<T>> GetAll() => await _entities.ToListAsync();
       
        public async Task<T> GetById(int id) => await _entities.FindAsync(id);

        public void Update(T entity) => _entities.Update(entity);
       
    }
}
