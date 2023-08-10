namespace AtencionMedica.Application.Interfaces
{
    public interface IComunaService
    {
        Task<ICollection<Comuna>> GetComunas();
        Task<Comuna> GetComuna(int id);
    }
}
