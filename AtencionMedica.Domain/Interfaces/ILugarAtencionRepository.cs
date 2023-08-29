namespace AtencionMedica.Domain.Interfaces
{
    public interface ILugarAtencionRepository
    {
        Task<ICollection<LugarAtencion>> GetAll();
        Task<LugarAtencion?> GetById(int id);
    }
}
