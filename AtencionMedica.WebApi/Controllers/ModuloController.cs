namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        private readonly IModuloService _moduloService;
        private readonly IMapper _mapper;

        public ModuloController(IModuloService moduloService, IMapper mapper)
        {
            _moduloService = moduloService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _moduloService.GetModulos();
            var modulosDtos = _mapper.Map<ICollection<ModuloGetDto>>(result);
            var response = new ApiResponse<ICollection<ModuloGetDto>>(modulosDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _moduloService.GetModulo(id);
            var moduloDto = _mapper.Map<ModuloGetDto>(result);
            var response = new ApiResponse<ModuloGetDto>(moduloDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] ModuloDto moduloDto)
        {
            var modulo = _mapper.Map<Modulo>(moduloDto);
            await _moduloService.Agregar(modulo);
            moduloDto = _mapper.Map<ModuloDto>(modulo);
            var response = new ApiResponse<ModuloDto>(moduloDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, ModuloDto moduloDto)
        {
            moduloDto.IdModulo = id;
            var modulo = _mapper.Map<Modulo>(moduloDto);
            modulo.Id = id;

            var result = await _moduloService.Actualizar(modulo);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _moduloService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
