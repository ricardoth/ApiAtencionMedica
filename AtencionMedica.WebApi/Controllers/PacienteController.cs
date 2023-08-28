namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteService pacienteService, IMapper mapper)
        {
            _pacienteService = pacienteService;        
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromQuery]PacienteQueryFilter filtros)
        {
            var result = await _pacienteService.GetPacientes(filtros);
            var metaData = new MetaData
            {
                TotalCount = result.TotalCount,
                PageSize = result.PageSize,
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages, 
                HasNextPage = result.HasNextPage,
                HasPreviousPage = result.HasPreviousPage,
            };

            var response = new ApiResponse<ICollection<Paciente>>(result)
            {
                MetaData = metaData
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _pacienteService.GetPaciente(id);
            var pacienteDto = _mapper.Map<PacienteDto>(result);
            var response = new ApiResponse<PacienteDto>(pacienteDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] PacienteDto pacienteDto)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDto);
            await _pacienteService.Agregar(paciente);
            pacienteDto = _mapper.Map<PacienteDto>(paciente);
            var response = new ApiResponse<PacienteDto>(pacienteDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(int id, PacienteDto pacienteDto)
        {
            pacienteDto.IdUsuario = id;
            var paciente = _mapper.Map<Paciente>(pacienteDto);
            paciente.Id = id;

            var result = await _pacienteService.Actualizar(paciente);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pacienteService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
