namespace AtencionMedica.Domain.Interfaces
{
    public interface IPacientePaginationRepository
    {
        Task<ICollection<Paciente>> GetPacientesPagination(int pageNumber, int pageSize);
        Task<int> GetTotalPacientesCount();
    }
}
