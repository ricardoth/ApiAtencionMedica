namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplicacionPacienteController : ControllerBase
    {
        private readonly IComplicacionPacienteService _complicacionPacienteService;
        private readonly IMapper _mapper;

        public ComplicacionPacienteController(IComplicacionPacienteService complicacionPacienteService, IMapper mapper)
        {
            _complicacionPacienteService = complicacionPacienteService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _complicacionPacienteService.GetComplicacionesPacientes();
            var complicacionPacienteDtos = _mapper.Map<ICollection<ComplicacionPacienteGetDto>>(result);
            var response = new ApiResponse<ICollection<ComplicacionPacienteGetDto>>(complicacionPacienteDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _complicacionPacienteService.GetComplicacionPaciente(id);
            var complicacionPacienteDto = _mapper.Map<ComplicacionPacienteGetDto>(result);
            var response = new ApiResponse<ComplicacionPacienteGetDto>(complicacionPacienteDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] ComplicacionPacienteDto complicacionPacienteDto)
        {
            var complicacionPaciente = _mapper.Map<ComplicacionPaciente>(complicacionPacienteDto);
            await _complicacionPacienteService.Agregar(complicacionPaciente);
            complicacionPacienteDto = _mapper.Map<ComplicacionPacienteDto>(complicacionPaciente);
            var response = new ApiResponse<ComplicacionPacienteDto>(complicacionPacienteDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, ComplicacionPacienteDto complicacionPacienteDto)
        {
            complicacionPacienteDto.IdComplicacion = id;
            var complicacionPaciente = _mapper.Map<ComplicacionPaciente>(complicacionPacienteDto);
            complicacionPaciente.Id = id;

            var result = await _complicacionPacienteService.Actualizar(complicacionPaciente);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _complicacionPacienteService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
