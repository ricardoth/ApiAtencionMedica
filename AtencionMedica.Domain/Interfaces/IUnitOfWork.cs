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
        IRepository<Personal> PersonalRepository { get; }
        IRepository<LugarAtencion> LugarAtencionRepository { get; }
        IRepository<AgendaMedico> AgendaMedicoRepository { get; }
        IRepository<EspecialidadMedico> EspecialidadMedicoRepository { get; }
        IRepository<FichaClinica> FichaClinicaRepository { get; }
        IRepository<FichaClinicaDetalle> FichaClinicaDetalleRepository { get; }
        IRepository<HistorialClinico> HistorialClinicoRepository { get; }
        IRepository<PatologiaPaciente> PatologiaPacienteRepository { get; }
        IRepository<RecetaMedica> RecetaMedicaRepository { get; }
        IRepository<ComplicacionPaciente> ComplicacionPacienteRepository { get; }
        IRepository<PacienteAdultoMayor> PacienteAdultoMayorRepository { get; }
        IRepository<PacienteDiabetico> PacienteDiabeticoRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
