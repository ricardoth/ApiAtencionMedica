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

        public async Task Add(T entity)
        {
            entity.FecCreacion = DateTime.Now;
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<ICollection<T>> GetAll() => await _context.Set<T>().ToListAsync();
       
        public async Task<T?> GetById(int id) => await _context.Set<T>().FindAsync(id);

        public void Update(T entity) 
        {
            entity.FecActualizacion = DateTime.Now;
            _context.Set<T>().Update(entity);
        } 

        public async Task<bool> SoftDelete(int id)
        {
            T? entity = await GetById(id);
            if (entity is null)
                return false;

            entity.EsActivo = false;
            entity.FecActualizacion = DateTime.Now;
            _context.Set<T>().Update(entity);
            return true;
        }

        public async Task<bool> HardDelete(int id)
        {
            T? entity = await GetById(id);
            if (entity is null)
                return false;

            _context.Set<T>().Remove(entity);
            return true;
        }
    }
}
