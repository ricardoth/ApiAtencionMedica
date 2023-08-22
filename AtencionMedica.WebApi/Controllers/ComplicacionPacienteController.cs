namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplicacionPacienteController : ControllerBase
    {
        private readonly IComplicacionPacienteService _complicacionPacienteService;
        private readonly IMapper _mapper;

        public ComplicacionPacienteController(IComplicacionPacienteService complicacionPacienteService, IMapper mapper)
        {
            _complicacionPacienteService = complicacionPacienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _complicacionPacienteService.GetComplicacionesPacientes();
            var complicacionPacienteDtos = _mapper.Map<ICollection<ComplicacionPacienteDto>>(result);
            var response = new ApiResponse<ICollection<ComplicacionPacienteDto>>(complicacionPacienteDtos);
            return Ok(response);
        }
    }
}
