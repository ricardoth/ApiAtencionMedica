namespace AtencionMedica.Application.Interfaces
{
    public interface IPacienteAdultoMayorService
    {
        Task<ICollection<PacienteAdultoMayor>> GetPacientesAdultosMayores();
        Task<PacienteAdultoMayor> GetPacienteAdultoMayor(int id);
        Task Agregar(PacienteAdultoMayor pacienteAdultoMayor);
        Task<bool> Actualizar(PacienteAdultoMayor pacienteAdultoMayor);
        Task<bool> Eliminar(int id);
    }
}
