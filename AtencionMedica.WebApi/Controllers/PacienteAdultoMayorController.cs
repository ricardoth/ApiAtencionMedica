namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PacienteAdultoMayorController : ControllerBase
    {
        private readonly IPacienteAdultoMayorService _pacienteAdultoMayorService;
        private readonly IMapper _mapper;

        public PacienteAdultoMayorController(IPacienteAdultoMayorService pacienteAdultoMayorService, IMapper mapper)
        {
            _pacienteAdultoMayorService = pacienteAdultoMayorService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _pacienteAdultoMayorService.GetPacientesAdultosMayores();
            var pacienteAdultoMayorGetDtos = _mapper.Map<ICollection<PacienteAdultoMayorGetDto>>(result);
            var response = new ApiResponse<ICollection<PacienteAdultoMayorGetDto>>(pacienteAdultoMayorGetDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _pacienteAdultoMayorService.GetPacienteAdultoMayor(id);
            var pacienteAdultoMayorGetDto = _mapper.Map<PacienteAdultoMayorGetDto>(result);
            var response = new ApiResponse<PacienteAdultoMayorGetDto>(pacienteAdultoMayorGetDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] PacienteAdultoMayorDto pacienteAdultoMayorDto)
        {
            var pacienteAdultoMayor = _mapper.Map<PacienteAdultoMayor>(pacienteAdultoMayorDto);
            await _pacienteAdultoMayorService.Agregar(pacienteAdultoMayor);
            pacienteAdultoMayorDto = _mapper.Map<PacienteAdultoMayorDto>(pacienteAdultoMayor);
            var response = new ApiResponse<PacienteAdultoMayorDto>(pacienteAdultoMayorDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, PacienteAdultoMayorDto pacienteAdultoMayorDto)
        {
            pacienteAdultoMayorDto.IdPacienteAdultoMayor = id;
            var pacienteAdultoMayor = _mapper.Map<PacienteAdultoMayor>(pacienteAdultoMayorDto);
            pacienteAdultoMayor.Id = id;

            var result = await _pacienteAdultoMayorService.Actualizar(pacienteAdultoMayor);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pacienteAdultoMayorService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
