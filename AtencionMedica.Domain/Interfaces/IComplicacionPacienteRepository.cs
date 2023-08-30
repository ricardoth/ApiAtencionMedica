namespace AtencionMedica.Domain.Interfaces
{
    public interface IComplicacionPacienteRepository
    {
        Task<ICollection<ComplicacionPaciente>> GetAll();
        Task<ComplicacionPaciente?> GetById(int id);
    }
}
