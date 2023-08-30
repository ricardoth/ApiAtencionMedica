namespace AtencionMedica.Domain.Interfaces
{
    public interface IPatologiaPacienteRepository
    {
        Task<ICollection<PatologiaPaciente>> GetAll();
        Task<PatologiaPaciente?> GetById(int id);
    }
}
