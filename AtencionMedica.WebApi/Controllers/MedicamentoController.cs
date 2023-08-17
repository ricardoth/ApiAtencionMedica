using AtencionMedica.Domain.Entities;

namespace AtencionMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoService _medicamentoService;
        private readonly IMapper _mapper;

        public MedicamentoController(IMedicamentoService medicamentoService, IMapper mapper)
        {
            _medicamentoService = medicamentoService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _medicamentoService.GetMedicamentos();
            var medicamentosDtos = _mapper.Map<ICollection<MedicamentoDto>>(result);
            var response = new ApiResponse<ICollection<MedicamentoDto>>(medicamentosDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _medicamentoService.GetMedicamento(id);
            var medicamentoDto = _mapper.Map<MedicamentoDto>(result);
            var response = new ApiResponse<MedicamentoDto>(medicamentoDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] MedicamentoDto medicamentoDto)
        {
            var medicamento = _mapper.Map<Medicamento>(medicamentoDto);
            await _medicamentoService.Agregar(medicamento);
            medicamentoDto = _mapper.Map<MedicamentoDto>(medicamento);
            var response = new ApiResponse<MedicamentoDto>(medicamentoDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, MedicamentoDto medicamentoDto)
        {
            medicamentoDto.IdMedicamento = id;
            var medicamento = _mapper.Map<Medicamento>(medicamentoDto);
            medicamento.Id = id;

            var result = await _medicamentoService.Actualizar(medicamento);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _medicamentoService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
