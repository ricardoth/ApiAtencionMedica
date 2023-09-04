namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaMedicoController : ControllerBase
    {
        private readonly IAgendaMedicoService _agendaMedicoService;
        private readonly IMapper _mapper;

        public AgendaMedicoController(IAgendaMedicoService agendaMedicoService, IMapper mapper)
        {
            _agendaMedicoService = agendaMedicoService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _agendaMedicoService.GetAgendasMedicos();
            var agendaMedicoGetDtos = _mapper.Map<ICollection<AgendaMedicoGetDto>>(result);
            var response = new ApiResponse<ICollection<AgendaMedicoGetDto>>(agendaMedicoGetDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _agendaMedicoService.GetAgendaMedico(id);
            var agendaMedicoGetDto = _mapper.Map<AgendaMedicoGetDto>(result);
            var response = new ApiResponse<AgendaMedicoGetDto>(agendaMedicoGetDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] AgendaMedicoDto agendaMedicoDto)
        {
            var agendaMedico = _mapper.Map<AgendaMedico>(agendaMedicoDto);
            await _agendaMedicoService.Agregar(agendaMedico);
            agendaMedicoDto = _mapper.Map<AgendaMedicoDto>(agendaMedico);
            var response = new ApiResponse<AgendaMedicoDto>(agendaMedicoDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, AgendaMedicoDto agendaMedicoDto)
        {
            agendaMedicoDto.IdAgendaMedico = id;
            var agendaMedico = _mapper.Map<AgendaMedico>(agendaMedicoDto);
            agendaMedico.Id = id;

            var result = await _agendaMedicoService.Actualizar(agendaMedico);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _agendaMedicoService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
