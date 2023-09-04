namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialClinicoController : ControllerBase
    {
        private readonly IHistorialClinicoService _historialClinicoService;
        private readonly IMapper _mapper;

        public HistorialClinicoController(IHistorialClinicoService historialClinicoService, IMapper mapper)
        {
            _historialClinicoService = historialClinicoService;
            _mapper = mapper;   
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _historialClinicoService.GetHistorialesClinicos();
            var historialClinicoGetDtos = _mapper.Map<ICollection<HistorialClinicoGetDto>>(result);
            var response = new ApiResponse<ICollection<HistorialClinicoGetDto>>(historialClinicoGetDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _historialClinicoService.GetHistorialClinico(id);
            var historialClinicoGetDto = _mapper.Map<HistorialClinicoGetDto>(result);
            var response = new ApiResponse<HistorialClinicoGetDto>(historialClinicoGetDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] HistorialClinicoDto historialClinicoDto)
        {
            var historialClinico = _mapper.Map<HistorialClinico>(historialClinicoDto);
            await _historialClinicoService.Agregar(historialClinico);
            historialClinicoDto = _mapper.Map<HistorialClinicoDto>(historialClinico);
            var response = new ApiResponse<HistorialClinicoDto>(historialClinicoDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, HistorialClinicoDto historialClinicoDto)
        {
            historialClinicoDto.IdHistorialClinico = id;
            var historialClinico = _mapper.Map<HistorialClinico>(historialClinicoDto);
            historialClinico.Id = id;

            var result = await _historialClinicoService.Actualizar(historialClinico);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _historialClinicoService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
