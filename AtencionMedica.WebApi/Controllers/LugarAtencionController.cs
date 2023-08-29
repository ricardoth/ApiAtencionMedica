namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugarAtencionController : ControllerBase
    {
        private readonly ILugarAtencionService _lugarAtencionService;
        private readonly IMapper _mapper;

        public LugarAtencionController(ILugarAtencionService lugarAtencionService, IMapper mapper)
        {
            _lugarAtencionService = lugarAtencionService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _lugarAtencionService.GetLugaresAtenciones();
            var lugarAtencionGetDto = _mapper.Map<ICollection<LugarAtencionGetDto>>(result);
            var response = new ApiResponse<ICollection<LugarAtencionGetDto>>(lugarAtencionGetDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _lugarAtencionService.GetLugarAtencion(id);
            var lugarAtencionGetDto = _mapper.Map<LugarAtencionGetDto>(result);
            var response = new ApiResponse<LugarAtencionGetDto>(lugarAtencionGetDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] LugarAtencionDto lugarAtencionDto)
        {
            var lugarAtencion = _mapper.Map<LugarAtencion>(lugarAtencionDto);
            await _lugarAtencionService.Agregar(lugarAtencion);
            lugarAtencionDto = _mapper.Map<LugarAtencionDto>(lugarAtencion);
            var response = new ApiResponse<LugarAtencionDto>(lugarAtencionDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, LugarAtencionDto lugarAtencionDto)
        {
            lugarAtencionDto.IdLugarAtencion = id;
            var lugarAtencion = _mapper.Map<LugarAtencion>(lugarAtencionDto);
            lugarAtencion.Id = id;

            var result = await _lugarAtencionService.Actualizar(lugarAtencion);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _lugarAtencionService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
