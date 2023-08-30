namespace AtencionMedica.Application.Interfaces
{
    public interface IFichaClinicaService
    {
        Task<ICollection<FichaClinica>> GetFichasClinicas();
        Task<FichaClinica> GetFichaClinica(int id);
        Task Agregar(FichaClinica fichaClinica);
        Task<bool> Actualizar(FichaClinica fichaClinica);
        Task<bool> Eliminar(int id);
    }
}
