namespace AtencionMedica.Domain.Interfaces
{
    public interface IPaginationRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllPagination(int pageNumber, int pageSize);
        Task<int> GetAllTotalCount();
    }
}
