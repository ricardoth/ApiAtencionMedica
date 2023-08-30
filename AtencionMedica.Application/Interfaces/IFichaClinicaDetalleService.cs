namespace AtencionMedica.Application.Interfaces
{
    public interface IFichaClinicaDetalleService
    {
        Task<ICollection<FichaClinicaDetalle>> GetFichasClinicasDetalles();
        Task<FichaClinicaDetalle> GetFichaClinicaDetalle(int id);
        Task Agregar(FichaClinicaDetalle fichaClinicaDetalle);
        Task<bool> Actualizar(FichaClinicaDetalle fichaClinicaDetalle);
        Task<bool> Eliminar(int id);
    }
}
