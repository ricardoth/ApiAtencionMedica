namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonalService _personalService;
        private readonly IMapper _mapper;

        public PersonalController(IPersonalService personalService, IMapper mapper)
        {
            _personalService = personalService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _personalService.GetPersonales();
            var personalesDtos = _mapper.Map<ICollection<PersonalDto>>(result);
            var response = new ApiResponse<ICollection<PersonalDto>>(personalesDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _personalService.GetPersonal(id);
            var personalDto = _mapper.Map<PersonalDto>(result);
            var response = new ApiResponse<PersonalDto>(personalDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] PersonalDto personalDto)
        {
            var personal = _mapper.Map<Personal>(personalDto);
            await _personalService.Agregar(personal);
            personalDto = _mapper.Map<PersonalDto>(personal);
            var response = new ApiResponse<PersonalDto>(personalDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, PersonalDto personalDto)
        {
            personalDto.IdPersonal = id;
            var personal = _mapper.Map<Personal>(personalDto);
            personal.Id = id;

            var result = await _personalService.Actualizar(personal);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personalService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
