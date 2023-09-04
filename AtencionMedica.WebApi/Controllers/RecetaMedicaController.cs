namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetaMedicaController : ControllerBase
    {
        private readonly IRecetaMedicaService _recetaMedicaService;
        private readonly IMapper _mapper;

        public RecetaMedicaController(IRecetaMedicaService recetaMedicaService, IMapper mapper)
        {
            _recetaMedicaService = recetaMedicaService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _recetaMedicaService.GetRecetaMedicas();
            var recetaMedicaGetDtos = _mapper.Map<ICollection<RecetaMedicaGetDto>>(result);
            var response = new ApiResponse<ICollection<RecetaMedicaGetDto>>(recetaMedicaGetDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _recetaMedicaService.GetRecetaMedica(id);
            var recetaMedicaGetDto = _mapper.Map<RecetaMedicaGetDto>(result);
            var response = new ApiResponse<RecetaMedicaGetDto>(recetaMedicaGetDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] RecetaMedicaDto recetaMedicaDto)
        {
            var recetaMedica = _mapper.Map<RecetaMedica>(recetaMedicaDto);
            await _recetaMedicaService.Agregar(recetaMedica);
            recetaMedicaDto = _mapper.Map<RecetaMedicaDto>(recetaMedica);
            var response = new ApiResponse<RecetaMedicaDto>(recetaMedicaDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, RecetaMedicaDto recetaMedicaDto)
        {
            recetaMedicaDto.IdRecetaMedica = id;
            var patologiaPaciente = _mapper.Map<RecetaMedica>(recetaMedicaDto);
            patologiaPaciente.Id = id;

            var result = await _recetaMedicaService.Actualizar(patologiaPaciente);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _recetaMedicaService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
