namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoFichaClinicaController : ControllerBase
    {
        private readonly IEstadoFichaClinicaService _estadoFichaClinicaService;
        private readonly IMapper _mapper;

        public EstadoFichaClinicaController(IEstadoFichaClinicaService estadoFichaClinicaService, IMapper mapper)
        {
            _estadoFichaClinicaService = estadoFichaClinicaService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _estadoFichaClinicaService.GetEstadoFichasClinicas();
            var estadoFichaClinicasDtos = _mapper.Map<ICollection<EstadoFichaClinicaDto>>(result);
            var response = new ApiResponse<ICollection<EstadoFichaClinicaDto>>(estadoFichaClinicasDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _estadoFichaClinicaService.GetEstadoFichaClinica(id);
            var estadoFichaClinicaDto = _mapper.Map<EstadoFichaClinicaDto>(result);
            var response = new ApiResponse<EstadoFichaClinicaDto>(estadoFichaClinicaDto);
            return Ok(response);    
        }
    }
}
