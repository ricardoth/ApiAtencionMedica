namespace AtencionMedica.Application.Interfaces
{
    public interface IComplicacionPacienteService
    {
        Task<ICollection<ComplicacionPaciente>> GetComplicacionesPacientes();
        Task<ComplicacionPaciente> GetComplicacionPaciente(int id);
        Task Agregar(ComplicacionPaciente complicacionPaciente);
        Task<bool> Actualizar(ComplicacionPaciente complicacionPaciente);
        Task<bool> Eliminar(int id);
    }
}
