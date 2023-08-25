namespace AtencionMedica.Application.Interfaces
{
    public interface IPacienteDiabeticoService
    {
        Task<ICollection<PacienteDiabetico>> GetPacientesDiabeticos();
        Task<PacienteDiabetico> GetPacienteDiabetico(int id);
        Task Agregar(PacienteDiabetico medico);
        Task<bool> Actualizar(PacienteDiabetico medico);
        Task<bool> Eliminar(int id);
    }
}
