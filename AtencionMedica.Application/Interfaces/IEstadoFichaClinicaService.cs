namespace AtencionMedica.Application.Interfaces
{
    public interface IEstadoFichaClinicaService
    {
        Task<ICollection<EstadoFichaClinica>> GetEstadoFichasClinicas();
        Task<EstadoFichaClinica> GetEstadoFichaClinica(int id);
    }
}
