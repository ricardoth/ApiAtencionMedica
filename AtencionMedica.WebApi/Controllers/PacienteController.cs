using AtencionMedica.Domain.QueryFilters;

namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;        
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PacienteQueryFilter filtros)
        {
            var result = await _pacienteService.GetPacientes(filtros);
            var metaData = new MetaData
            {
                TotalCount = result.TotalCount,
                PageSize = result.PageSize,
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages, 
                HasNextPage = result.HasNextPage,
                HasPreviousPage = result.HasPreviousPage,
            };

            var response = new ApiResponse<ICollection<Paciente>>(result)
            {
                MetaData = metaData
            };

            return Ok(response);

        }
    }
}
