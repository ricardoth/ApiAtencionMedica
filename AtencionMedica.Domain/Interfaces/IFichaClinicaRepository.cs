namespace AtencionMedica.Domain.Interfaces
{
    public interface IFichaClinicaRepository
    {
        Task<ICollection<FichaClinica>> GetAll();
        Task<FichaClinica?> GetById(int id);
    }
}
