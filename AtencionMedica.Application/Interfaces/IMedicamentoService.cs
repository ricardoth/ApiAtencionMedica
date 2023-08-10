namespace AtencionMedica.Application.Interfaces
{
    public interface IMedicamentoService
    {
        Task<ICollection<Medicamento>> GetMedicamentos();
        Task<Medicamento> GetMedicamento(int id);
        Task Agregar(Medicamento medicamento);
        Task<bool> Actualizar(Medicamento medicamento);
        Task<bool> Eliminar(int id);
    }
}
