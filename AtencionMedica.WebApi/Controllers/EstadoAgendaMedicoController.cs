namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoAgendaMedicoController : ControllerBase
    {
        private readonly IEstadoAgendaMedicoService _estadoAgendaMedicoService;
        private readonly IMapper _mapper;

        public EstadoAgendaMedicoController(IEstadoAgendaMedicoService estadoAgendaMedicoService, IMapper mapper)
        {
            _estadoAgendaMedicoService = estadoAgendaMedicoService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _estadoAgendaMedicoService.GetEstadoAgendasMedicos();
            var estadoAgendasMedicosDtos = _mapper.Map<ICollection<EstadoAgendaMedicoDto>>(result);
            var response = new ApiResponse<ICollection<EstadoAgendaMedicoDto>>(estadoAgendasMedicosDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _estadoAgendaMedicoService.GetEstadoAgendaMedico(id);
            var estadoAgendaMedicoDto = _mapper.Map<EstadoAgendaMedicoDto>(result);
            var response = new ApiResponse<EstadoAgendaMedicoDto>(estadoAgendaMedicoDto);
            return Ok(response);
        }
    }
}
