namespace AtencionMedica.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T?> GetById(int id);
        Task Add(T entity);
        void Update(T entity);  
        Task<bool> SoftDelete(int id);    
        Task<bool> HardDelete(int id);
    }
}
