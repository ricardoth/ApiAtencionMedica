namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadMedicoController : ControllerBase
    {
        private readonly IEspecialidadMedicoService _especialidadMedicoService;
        private readonly IMapper _mapper;

        public EspecialidadMedicoController(IEspecialidadMedicoService especialidadMedicoService,
            IMapper mapper)
        {
            _especialidadMedicoService = especialidadMedicoService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _especialidadMedicoService.GetEspecialidadesMedicos();
            var especialidadMedicoGetDtos = _mapper.Map<ICollection<EspecialidadMedicoGetDto>>(result);
            var response = new ApiResponse<ICollection<EspecialidadMedicoGetDto>>(especialidadMedicoGetDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _especialidadMedicoService.GetEspecialidadMedico(id);
            var especialidadMedicoGetDto = _mapper.Map<EspecialidadMedicoGetDto>(result);
            var response = new ApiResponse<EspecialidadMedicoGetDto>(especialidadMedicoGetDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] EspecialidadMedicoDto especialidadMedicoDto)
        {
            var especialidadMedico = _mapper.Map<EspecialidadMedico>(especialidadMedicoDto);
            await _especialidadMedicoService.Agregar(especialidadMedico);
            especialidadMedicoDto = _mapper.Map<EspecialidadMedicoDto>(especialidadMedico);
            var response = new ApiResponse<EspecialidadMedicoDto>(especialidadMedicoDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, EspecialidadMedicoDto especialidadMedicoDto)
        {
            especialidadMedicoDto.IdEspecialidadMedico = id;
            var especialidadMedico = _mapper.Map<EspecialidadMedico>(especialidadMedicoDto);
            especialidadMedico.Id = id;

            var result = await _especialidadMedicoService.Actualizar(especialidadMedico);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _especialidadMedicoService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
