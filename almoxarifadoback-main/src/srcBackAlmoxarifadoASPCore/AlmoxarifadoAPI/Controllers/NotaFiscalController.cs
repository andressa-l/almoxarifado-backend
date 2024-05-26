using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlmoxarifadoAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class NotaFiscalController : ControllerBase {
        private readonly NotaFiscalService _notaFiscalService;

        public NotaFiscalController(NotaFiscalService notaFiscalService) {
            _notaFiscalService = notaFiscalService;
        }

        [HttpGet]
        public IActionResult Get() {
            try {
                var notasFiscais = _notaFiscalService.GetNotasFiscais();
                return Ok(notasFiscais);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult CriarNotaFiscal(NotaFiscalPostDTO notaFiscal) {
            try {
                var notaFiscalSalva = _notaFiscalService.CriarNotaFiscal(notaFiscal);
                return Ok(notaFiscalSalva);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("/NotaFiscal/{notaFiscal}")]
        public IActionResult GetById(int notaFiscal) {
            try {
                var notasFiscais = _notaFiscalService.GetById(notaFiscal);
                if (notasFiscais == null) {
                    return StatusCode(404, "Nenhuma Nota Fiscal Encontrada com Esse Codigo");
                }
                return Ok(notasFiscais);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NotaFiscalPostDTO notaFiscalPostDTO) {
            var updatedNotaFiscal = await _notaFiscalService.Update(notaFiscalPostDTO);
            return Ok(updatedNotaFiscal);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var deleted = await _notaFiscalService.Delete(id);
            if (deleted == null) {
                return NotFound("Nota fiscal não encontrada.");
            }
            return Ok(deleted);
        }
    }
}
