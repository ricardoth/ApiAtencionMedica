namespace AtencionMedica.Domain.Interfaces
{
    public interface IPacienteAdultoMayorRepository
    {
        Task<ICollection<PacienteAdultoMayor>> GetAll();
        Task<PacienteAdultoMayor?> GetById(int id);
        Task Add(PacienteAdultoMayor entity);
        Task Update(PacienteAdultoMayor entity);
        Task<bool> Delete(int id);
    }
}
