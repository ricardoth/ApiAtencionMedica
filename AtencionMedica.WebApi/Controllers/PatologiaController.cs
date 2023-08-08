namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatologiaController : ControllerBase
    {
        private readonly IPatologiaService _patologiaService;

        public PatologiaController(IPatologiaService patologiaService)
        {
            _patologiaService = patologiaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        { 
            var result = await _patologiaService.GetPatologias();
            if (result == null)
                return BadRequest();

            return Ok(result);  
        }
    }
}
