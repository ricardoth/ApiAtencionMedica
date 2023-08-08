namespace AtencionMedica.Domain.Interfaces.InterfaceServices
{
    public interface IPatologiaService
    {
        Task<ICollection<Patologia>> GetPatologias();
    }
}
