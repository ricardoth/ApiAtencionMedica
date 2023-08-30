namespace AtencionMedica.Application.Interfaces
{
    public interface IRecetaMedicaService
    {
        Task<ICollection<RecetaMedica>> GetRecetaMedicas();
        Task<RecetaMedica> GetRecetaMedica(int id);
        Task Agregar(RecetaMedica recetaMedica);
        Task<bool> Actualizar(RecetaMedica recetaMedica);
        Task<bool> Eliminar(int id);
    }
}
