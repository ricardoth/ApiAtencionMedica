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
        //private readonly IRepository<PacienteAdultoMayor> _pacienteAdultoMayorRepository;
        //private readonly IRepository<PacienteDiabetico> _pacienteDiabeticoRepository;
        private readonly IRepository<Personal> _personalRepository;
        
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
        //public IRepository<PacienteAdultoMayor> PacienteAdultoMayorRepository => _pacienteAdultoMayorRepository ?? new BaseRepository<PacienteAdultoMayor>(_context);
        //public IRepository<PacienteDiabetico> PacienteDiabeticoRepository => _pacienteDiabeticoRepository ?? new BaseRepository<PacienteDiabetico>(_context);  
        public IRepository<Personal> PersonalRepository => _personalRepository ?? new BaseRepository<Personal>(_context);

        public void Dispose()
        { 
            if ( _context != null)
                _context.Dispose();
        }

        public void SaveChanges() => _context.SaveChanges();

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
