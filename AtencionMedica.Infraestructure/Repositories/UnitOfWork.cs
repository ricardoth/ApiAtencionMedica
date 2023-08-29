using AtencionMedica.Domain.Exceptions;

namespace AtencionMedica.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AtencionMedicaContext _context;
        private readonly IRepository<Complicacion> _complicacionRepository;
        private readonly IRepository<Comuna> _comunaRepository;
        private readonly IRepository<Especialidad> _especialidadRepository;
        private readonly IRepository<EstadoAgendaMedico> _estadoAgendaMedicoRepository;
        private readonly IRepository<EstadoFichaClinica> _estadoFichaClinicaRepository;
        private readonly IRepository<Medicamento> _medicamentoRepository;
        private readonly IRepository<Patologia> _patologiaRepository;
        private readonly IRepository<Medico> _medicoRepository;
        private readonly IRepository<Modulo> _moduloRepository;
        private readonly IRepository<Paciente> _pacienteRepository;
        private readonly IRepository<Personal> _personalRepository;
        private readonly IRepository<LugarAtencion> _lugarAtencionRepository;
        private readonly IRepository<AgendaMedico> _agendaMedicoRepository;
        private readonly IRepository<EspecialidadMedico> _especialidadMedicoRepository;
        private readonly IRepository<FichaClinica> _fichaClinicaRepository;
        private readonly IRepository<FichaClinicaDetalle> _fichaClinicaDetalleRepository;
        private readonly IRepository<HistorialClinico> _historialClinicoRepository;
        private readonly IRepository<PatologiaPaciente> _patologiaPacienteRepository;
        private readonly IRepository<RecetaMedica> _recetaMedicaRepository;
        private readonly IRepository<PacienteDiabetico> _pacienteDiabeticoRepository;
        private readonly IRepository<PacienteAdultoMayor> _pacienteAdultoMayorRepository;
        private readonly IRepository<ComplicacionPaciente> _complicacionPacienteRepository;

        public UnitOfWork(AtencionMedicaContext context)
        {
            _context = context;
        }

        public IRepository<Complicacion> ComplicacionRepository => _complicacionRepository ?? new BaseRepository<Complicacion>(_context);
        public IRepository<Comuna> ComunaRepository => _comunaRepository ?? new BaseRepository<Comuna>(_context);
        public IRepository<Especialidad> EspecialidadRepository => _especialidadRepository ?? new BaseRepository<Especialidad>(_context);
        public IRepository<EstadoAgendaMedico> EstadoAgendaMedicoRepository => _estadoAgendaMedicoRepository ?? new BaseRepository<EstadoAgendaMedico>(_context);
        public IRepository<EstadoFichaClinica> EstadoFichaClinicaRepository => _estadoFichaClinicaRepository ?? new BaseRepository<EstadoFichaClinica>(_context);
        public IRepository<Medicamento> MedicamentoRepository => _medicamentoRepository ?? new BaseRepository<Medicamento>(_context);
        public IRepository<Patologia> PatologiaRepository => _patologiaRepository ?? new BaseRepository<Patologia>(_context);
        public IRepository<Medico> MedicoRepository => _medicoRepository ?? new BaseRepository<Medico>(_context);
        public IRepository<Modulo> ModuloRepository => _moduloRepository ?? new BaseRepository<Modulo>(_context);
        public IRepository<Paciente> PacienteRepository => _pacienteRepository ?? new BaseRepository<Paciente>(_context);
        public IRepository<Personal> PersonalRepository => _personalRepository ?? new BaseRepository<Personal>(_context);
        public IRepository<LugarAtencion> LugarAtencionRepository => _lugarAtencionRepository ?? new BaseRepository<LugarAtencion>(_context);
        public IRepository<AgendaMedico> AgendaMedicoRepository => _agendaMedicoRepository ?? new BaseRepository<AgendaMedico>(_context);
        public IRepository<EspecialidadMedico> EspecialidadMedicoRepository => _especialidadMedicoRepository ?? new BaseRepository<EspecialidadMedico>(_context);
        public IRepository<FichaClinica> FichaClinicaRepository => _fichaClinicaRepository ?? new BaseRepository<FichaClinica>(_context);
        public IRepository<FichaClinicaDetalle> FichaClinicaDetalleRepository => _fichaClinicaDetalleRepository ?? new BaseRepository<FichaClinicaDetalle>(_context);
        public IRepository<HistorialClinico> HistorialClinicoRepository => _historialClinicoRepository ?? new BaseRepository<HistorialClinico>(_context);
        public IRepository<PatologiaPaciente> PatologiaPacienteRepository => _patologiaPacienteRepository ?? new BaseRepository<PatologiaPaciente>(_context);
        public IRepository<RecetaMedica> RecetaMedicaRepository => _recetaMedicaRepository ?? new BaseRepository<RecetaMedica>(_context);
        public IRepository<PacienteDiabetico> PacienteDiabeticoRepository => _pacienteDiabeticoRepository ?? new BaseRepository<PacienteDiabetico>(_context);
        public IRepository<PacienteAdultoMayor> PacienteAdultoMayorRepository => _pacienteAdultoMayorRepository ?? new BaseRepository<PacienteAdultoMayor>(_context);
        public IRepository<ComplicacionPaciente> ComplicacionPacienteRepository => _complicacionPacienteRepository ?? new BaseRepository<ComplicacionPaciente>(_context);

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public void SaveChanges() 
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                throw new BadRequestException($"Ha ocurrido un conflicto de concurrencia: {concurrencyException.Message}");
            }
        } 

        public async Task SaveChangesAsync() 
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                throw new BadRequestException($"Ha ocurrido un conflicto de concurrencia: {concurrencyException.Message}");
            }
        } 
    }
}
