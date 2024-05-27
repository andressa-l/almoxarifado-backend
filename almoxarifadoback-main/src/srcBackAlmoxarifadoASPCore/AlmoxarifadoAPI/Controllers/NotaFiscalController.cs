using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class NotaFiscalController : ControllerBase 
    {
        private readonly NotaFiscalService _notaFiscalService;
        public NotaFiscalController(NotaFiscalService notaFiscalService) 
        {
            _notaFiscalService = notaFiscalService;
        }

        [HttpGet]
        public IActionResult Get() {
            try {
                var notasFiscais = _notaFiscalService.ObterTodasNotasFiscais();
                return Ok(notasFiscais);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("/NotaFiscal/{notaFiscal}")]
        public IActionResult GetById(int notaFiscal) {
            try {
                var notasFiscais = _notaFiscalService.ObterNotaFiscalPorId(notaFiscal);
                if (notasFiscais == null) {
                    return StatusCode(404, "Nenhuma Nota Fiscal Encontrada com Esse Codigo");
                }
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

        [HttpPut("{id}")]
        public IActionResult AtualizarNotaFiscal(int id, NotaFiscalPutDTO notaFiscal) 
        {
            try {
                var notaFiscalNova = _notaFiscalService.AtualizarNotaFiscal(id, notaFiscal);
                if (notaFiscalNova == null) {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }
                return Ok(notaFiscalNova);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try {
                var notaFiscal = _notaFiscalService.ObterNotaFiscalPorId(id);
                if (notaFiscal == null) {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }

                var notaFiscalDeletada = _notaFiscalService.DeletarNotaFiscal(notaFiscal);
                if (notaFiscalDeletada == null) {
                    return StatusCode(404, "Ocorreu um erro ao excluir o item");
                }
                return Ok(notaFiscal);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }   
    }
}
