namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatologiaController : ControllerBase
    {
        private readonly IPatologiaService _patologiaService;
        private readonly IMapper _mapper;

        public PatologiaController(IPatologiaService patologiaService, IMapper mapper)
        {
            _patologiaService = patologiaService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _patologiaService.GetPatologias();
            if (result == null)
                return BadRequest();

            var patologiasDto = _mapper.Map<ICollection<PatologiaDto>>(result);
            return Ok(patologiasDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _patologiaService.GetPatologia(id);
            if (result == null)
                return NotFound();

            var patologiaDto = _mapper.Map<Patologia>(result);

            return Ok(patologiaDto);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] PatologiaDto patologiaDto)
        {
            var patologia = _mapper.Map<Patologia>(patologiaDto);
            await _patologiaService.Agregar(patologia);
            patologiaDto = _mapper.Map<PatologiaDto>(patologia);
            return Ok(patologia);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, PatologiaDto patologiaDto)
        {
            if (patologiaDto == null)
                return NotFound();

            patologiaDto.IdPatologia = id;
            var patologia = _mapper.Map<Patologia>(patologiaDto);
            patologia.Id = id;

            var result = await _patologiaService.Actualizar(patologia);
            if (!result)
                return BadRequest();

            return Ok(result);  
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            if(id == 0)
                return NoContent();

            var result = await _patologiaService.Eliminar(id);

            if(!result)
                return BadRequest();

            return Ok(result);
        }
    }
}
