namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteDiabeticoController : ControllerBase
    {
        private readonly IPacienteDiabeticoService _pacienteDiabeticoService;
        private readonly IMapper _mapper;

        public PacienteDiabeticoController(IPacienteDiabeticoService pacienteDiabeticoService, IMapper mapper)
        {
            _pacienteDiabeticoService = pacienteDiabeticoService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _pacienteDiabeticoService.GetPacientesDiabeticos();
            var pacienteDiabeticoGetDtos = _mapper.Map<ICollection<PacienteDiabeticoGetDto>>(result);
            var response = new ApiResponse<ICollection<PacienteDiabeticoGetDto>>(pacienteDiabeticoGetDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _pacienteDiabeticoService.GetPacienteDiabetico(id);
            var pacienteDiabeticoGetDto = _mapper.Map<PacienteDiabeticoGetDto>(result);
            var response = new ApiResponse<PacienteDiabeticoGetDto>(pacienteDiabeticoGetDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] PacienteDiabeticoDto pacienteDiabeticoDto)
        {
            var pacienteDiabetico = _mapper.Map<PacienteDiabetico>(pacienteDiabeticoDto);
            await _pacienteDiabeticoService.Agregar(pacienteDiabetico);
            pacienteDiabeticoDto = _mapper.Map<PacienteDiabeticoDto>(pacienteDiabetico);
            var response = new ApiResponse<PacienteDiabeticoDto>(pacienteDiabeticoDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, PacienteDiabeticoDto pacienteDiabeticoDto)
        {
            pacienteDiabeticoDto.IdPacienteDiabetico = id;
            var pacienteDiabetico = _mapper.Map<PacienteDiabetico>(pacienteDiabeticoDto);
            pacienteDiabetico.Id = id;

            var result = await _pacienteDiabeticoService.Actualizar(pacienteDiabetico);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pacienteDiabeticoService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
