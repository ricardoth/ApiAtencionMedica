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
            var patologiasDto = _mapper.Map<ICollection<PatologiaDto>>(result);
            var response = new ApiResponse<ICollection<PatologiaDto>>(patologiasDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _patologiaService.GetPatologia(id);
            var patologiaDto = _mapper.Map<PatologiaDto>(result);
            var response = new ApiResponse<PatologiaDto>(patologiaDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] PatologiaDto patologiaDto)
        {
            var patologia = _mapper.Map<Patologia>(patologiaDto);
            await _patologiaService.Agregar(patologia);
            patologiaDto = _mapper.Map<PatologiaDto>(patologia);
            var response = new ApiResponse<PatologiaDto>(patologiaDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, PatologiaDto patologiaDto)
        {
            patologiaDto.IdPatologia = id;
            var patologia = _mapper.Map<Patologia>(patologiaDto);
            patologia.Id = id;

            var result = await _patologiaService.Actualizar(patologia);
            var response = new ApiResponse<bool>(result);
            return Ok(response);  
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _patologiaService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
