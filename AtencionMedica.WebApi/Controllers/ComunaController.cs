namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunaController : ControllerBase
    {
        private readonly IComunaService _comunaService;
        private readonly IMapper _mapper;

        public ComunaController(IComunaService comunaService, IMapper mapper)
        {
            _comunaService = comunaService;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _comunaService.GetComunas();
            var comunasDtos = _mapper.Map<ICollection<ComunaDto>>(result);
            var response = new ApiResponse<ICollection<ComunaDto>>(comunasDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _comunaService.GetComuna(id);
            var comunaDto = _mapper.Map<ComunaDto>(result);
            var response = new ApiResponse<ComunaDto>(comunaDto);
            return Ok(response);
        }

    }
}
