namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        private readonly IMapper _mapper;

        public MedicoController(IMedicoService medicoService, IMapper mapper)
        {
            _medicoService = medicoService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromQuery] MedicoQueryFilter filtros)
        {
            var result = await _medicoService.GetMedicos(filtros);
            var metaData = new MetaData
            {
                TotalCount = result.TotalCount,
                PageSize = result.PageSize,
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                HasNextPage = result.HasNextPage,
                HasPreviousPage = result.HasPreviousPage,
            };

            var response = new ApiResponse<ICollection<Medico>>(result)
            {
                MetaData = metaData
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _medicoService.GetMedico(id);
            var medicoDto = _mapper.Map<MedicoDto>(result);
            var response = new ApiResponse<MedicoDto>(medicoDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] MedicoDto medicoDto)
        {
            var medico = _mapper.Map<Medico>(medicoDto);
            await _medicoService.Agregar(medico);
            medicoDto = _mapper.Map<MedicoDto>(medico);
            var response = new ApiResponse<MedicoDto>(medicoDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(int id, MedicoDto medicoDto)
        {
            medicoDto.IdMedico = id;
            var medico = _mapper.Map<Medico>(medicoDto);
            medico.Id = id;

            var result = await _medicoService.Actualizar(medico);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _medicoService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
