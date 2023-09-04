namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaClinicaDetalleController : ControllerBase
    {
        private readonly IFichaClinicaDetalleService _fichaClinicaDetalleService;
        private readonly IMapper _mapper;

        public FichaClinicaDetalleController(IFichaClinicaDetalleService fichaClinicaDetalleService, IMapper mapper)
        {
            _fichaClinicaDetalleService = fichaClinicaDetalleService;
            _mapper = mapper;   
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _fichaClinicaDetalleService.GetFichasClinicasDetalles();
            var fichaClinicaDetalleGetDtos = _mapper.Map<ICollection<FichaClinicaDetalleGetDto>>(result);
            var response = new ApiResponse<ICollection<FichaClinicaDetalleGetDto>>(fichaClinicaDetalleGetDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _fichaClinicaDetalleService.GetFichaClinicaDetalle(id);
            var fichaClinicaDetalleGetDto = _mapper.Map<FichaClinicaDetalleGetDto>(result);
            var response = new ApiResponse<FichaClinicaDetalleGetDto>(fichaClinicaDetalleGetDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] FichaClinicaDetalleDto fichaClinicaDetalleDto)
        {
            var fichaClinicaDetalle = _mapper.Map<FichaClinicaDetalle>(fichaClinicaDetalleDto);
            await _fichaClinicaDetalleService.Agregar(fichaClinicaDetalle);
            fichaClinicaDetalleDto = _mapper.Map<FichaClinicaDetalleDto>(fichaClinicaDetalle);
            var response = new ApiResponse<FichaClinicaDetalleDto>(fichaClinicaDetalleDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, FichaClinicaDetalleDto fichaClinicaDetalleDto)
        {
            fichaClinicaDetalleDto.IdFichaClinicaDetalle = id;
            var fichaClinicaDetalle = _mapper.Map<FichaClinicaDetalle>(fichaClinicaDetalleDto);
            fichaClinicaDetalle.Id = id;

            var result = await _fichaClinicaDetalleService.Actualizar(fichaClinicaDetalle);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _fichaClinicaDetalleService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
