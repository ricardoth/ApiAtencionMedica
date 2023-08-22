namespace AtencionMedica.Domain.Interfaces
{
    public interface IComplicacionPacienteRepository
    {
        Task<ICollection<ComplicacionPaciente>> GetComplicacionPacientes();
        Task<ComplicacionPaciente?> GetComplicacionPaciente(int id);
        Task Add(ComplicacionPaciente entity);
        Task Update(ComplicacionPaciente entity);
        Task<bool> Delete(int id);
    }
}
