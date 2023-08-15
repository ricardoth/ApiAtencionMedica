namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly IEspecialidadService _especialidadService;
        private readonly IMapper _mapper;

        public EspecialidadController(IEspecialidadService especialidadService, 
            IMapper mapper)
        {
            _especialidadService = especialidadService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _especialidadService.GetEspecialidades();
            var especialidadesDto = _mapper.Map<ICollection<EspecialidadDto>>(result);
            var response = new ApiResponse<ICollection<EspecialidadDto>>(especialidadesDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _especialidadService.GetEspecialidad(id);
            var especialidadDto = _mapper.Map<EspecialidadDto>(result);
            var response = new ApiResponse<EspecialidadDto>(especialidadDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] EspecialidadDto especialidadDto)
        {
            var especialidad = _mapper.Map<Especialidad>(especialidadDto);
            await _especialidadService.Agregar(especialidad);
            especialidadDto = _mapper.Map<EspecialidadDto>(especialidad);
            var response = new ApiResponse<EspecialidadDto>(especialidadDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, EspecialidadDto especialidadDto)
        {
            especialidadDto.IdEspecialidad = id;
            var especialidad = _mapper.Map<Especialidad>(especialidadDto);
            especialidad.Id = id;

            var result = await _especialidadService.Actualizar(especialidad);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _especialidadService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
