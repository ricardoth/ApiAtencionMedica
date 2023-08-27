namespace AtencionMedica.Application.Interfaces
{
    public interface IPacienteDiabeticoService
    {
        Task<ICollection<PacienteDiabetico>> GetPacientesDiabeticos();
        Task<PacienteDiabetico> GetPacienteDiabetico(int id);
        Task Agregar(PacienteDiabetico pacienteDiabetico);
        Task<bool> Actualizar(PacienteDiabetico pacienteDiabetico);
        Task<bool> Eliminar(int id);
    }
}
