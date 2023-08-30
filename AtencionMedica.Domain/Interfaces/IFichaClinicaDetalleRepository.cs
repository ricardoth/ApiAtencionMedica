namespace AtencionMedica.Domain.Interfaces
{
    public interface IFichaClinicaDetalleRepository
    {
        Task<ICollection<FichaClinicaDetalle>> GetAll();
        Task<FichaClinicaDetalle?> GetById(int id);
    }
}
