namespace AtencionMedica.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Complicacion> ComplicacionRepository { get; }
        IRepository<Comuna> ComunaRepository { get; }
        IRepository<Especialidad> EspecialidadRepository { get; }
        IRepository<EstadoAgendaMedico> EstadoAgendaMedicoRepository { get; }
        IRepository<EstadoFichaClinica> EstadoFichaClinicaRepository { get; }
        IRepository<Medicamento> MedicamentoRepository { get; }
        IRepository<Patologia> PatologiaRepository { get; }
        IRepository<Medico> MedicoRepository { get; }
        IRepository<Modulo> ModuloRepository { get; }
        IRepository<Paciente> PacienteRepository { get; }
        //IRepository<PacienteAdultoMayor> PacienteAdultoMayorRepository { get; }
        //IRepository<PacienteDiabetico> PacienteDiabeticoRepository { get; }
        IRepository<Personal> PersonalRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
