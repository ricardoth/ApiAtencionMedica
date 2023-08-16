namespace AtencionMedica.Application.Services
{
    public class EstadoAgendaMedicoService : IEstadoAgendaMedicoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstadoAgendaMedicoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<EstadoAgendaMedico> GetEstadoAgendaMedico(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EstadoAgendaMedico>> GetEstadoAgendasMedicos()
        {
            throw new NotImplementedException();
        }
    }
}
