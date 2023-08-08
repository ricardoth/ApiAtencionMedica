namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplicacionController : ControllerBase
    {
        private readonly IComplicacionService _complicacionService;
        private readonly IMapper _mapper;

        public ComplicacionController(IComplicacionService complicacionService, IMapper mapper)
        {
            _complicacionService = complicacionService;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _complicacionService.GetComplicaciones();
            if (result == null)
                return BadRequest();

            var complicacionesDto = _mapper.Map<ICollection<ComplicacionDto>>(result);
            var response = new ApiResponse<ICollection<ComplicacionDto>>(complicacionesDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _complicacionService.GetComplicacion(id);
            if (result == null)
                return NotFound();

            var complicacionDto = _mapper.Map<ComplicacionDto>(result);
            var response = new ApiResponse<ComplicacionDto>(complicacionDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] ComplicacionDto complicacionDto)
        {
            var complicacion = _mapper.Map<Complicacion>(complicacionDto);
            await _complicacionService.Agregar(complicacion);
            complicacionDto = _mapper.Map<ComplicacionDto>(complicacion);
            var response = new ApiResponse<ComplicacionDto>(complicacionDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, ComplicacionDto complicacionDto)
        {
            if (complicacionDto == null)
                return NotFound();

            complicacionDto.IdComplicacion = id;
            var complicacion = _mapper.Map<Complicacion>(complicacionDto);
            complicacion.Id = id;

            var result = await _complicacionService.Actualizar(complicacion);
            if (!result)
                return BadRequest();

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NoContent();

            var result = await _complicacionService.Eliminar(id);

            if (!result)
                return BadRequest();

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
