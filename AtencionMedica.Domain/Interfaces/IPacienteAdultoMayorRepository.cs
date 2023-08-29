namespace AtencionMedica.Domain.Interfaces
{
    public interface IPacienteAdultoMayorRepository
    {
        Task<ICollection<PacienteAdultoMayor>> GetAll();
        Task<PacienteAdultoMayor?> GetById(int id);
    }
}
