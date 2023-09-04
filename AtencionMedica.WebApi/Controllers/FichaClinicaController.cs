namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaClinicaController : ControllerBase
    {
        private readonly IFichaClinicaService _fichaClinicaService;
        private readonly IMapper _mapper;

        public FichaClinicaController(IFichaClinicaService fichaClinicaService, IMapper mapper)
        {
            _fichaClinicaService = fichaClinicaService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _fichaClinicaService.GetFichasClinicas();
            var fichaClinicaGetDtos = _mapper.Map<ICollection<FichaClinicaGetDto>>(result);
            var response = new ApiResponse<ICollection<FichaClinicaGetDto>>(fichaClinicaGetDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _fichaClinicaService.GetFichaClinica(id);
            var fichaClinicaGetDto = _mapper.Map<FichaClinicaGetDto>(result);
            var response = new ApiResponse<FichaClinicaGetDto>(fichaClinicaGetDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] FichaClinicaDto fichaClinicaDto)
        {
            var fichaClinica = _mapper.Map<FichaClinica>(fichaClinicaDto);
            await _fichaClinicaService.Agregar(fichaClinica);
            fichaClinicaDto = _mapper.Map<FichaClinicaDto>(fichaClinica);
            var response = new ApiResponse<FichaClinicaDto>(fichaClinicaDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, FichaClinicaDto fichaClinicaDto)
        {
            fichaClinicaDto.IdFichaClinica = id;
            var fichaClinica = _mapper.Map<FichaClinica>(fichaClinicaDto);
            fichaClinica.Id = id;

            var result = await _fichaClinicaService.Actualizar(fichaClinica);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _fichaClinicaService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
