namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatologiaPacienteController : ControllerBase
    {
        private readonly IPatologiaPacienteService _patologiaPacienteService;
        private readonly IMapper _mapper;

        public PatologiaPacienteController(IPatologiaPacienteService patologiaPacienteService, IMapper mapper)
        {
            _patologiaPacienteService = patologiaPacienteService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _patologiaPacienteService.GetPatologiasPacientes();
            var patologiaPacienteGetDtos = _mapper.Map<ICollection<PatologiaPacienteGetDto>>(result);
            var response = new ApiResponse<ICollection<PatologiaPacienteGetDto>>(patologiaPacienteGetDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _patologiaPacienteService.GetPatologiaPaciente(id);
            var patologiaPacienteGetDto = _mapper.Map<PatologiaPacienteGetDto>(result);
            var response = new ApiResponse<PatologiaPacienteGetDto>(patologiaPacienteGetDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] PatologiaPacienteDto patologiaPacienteDto)
        {
            var patologiaPaciente = _mapper.Map<PatologiaPaciente>(patologiaPacienteDto);
            await _patologiaPacienteService.Agregar(patologiaPaciente);
            patologiaPacienteDto = _mapper.Map<PatologiaPacienteDto>(patologiaPaciente);
            var response = new ApiResponse<PatologiaPacienteDto>(patologiaPacienteDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, PatologiaPacienteDto patologiaPacienteDto)
        {
            patologiaPacienteDto.IdPatologiaPaciente = id;
            var patologiaPaciente = _mapper.Map<PatologiaPaciente>(patologiaPacienteDto);
            patologiaPaciente.Id = id;

            var result = await _patologiaPacienteService.Actualizar(patologiaPaciente);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _patologiaPacienteService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
