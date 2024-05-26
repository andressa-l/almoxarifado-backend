using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ItensNotaController : ControllerBase {

        private readonly ItensNotaService _itensNotaService;
        public ItensNotaController(ItensNotaService itensNotaService) {
            _itensNotaService = itensNotaService;
        }

        [HttpGet]
        public IActionResult Get() {
            try {
                var itensNota = _itensNotaService.GetItensNota();
                return Ok(itensNota);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult CriarItemNota(ItensNotaPostDTO itemNota) {
            try {
                var itemNotaSalvo = _itensNotaService.CriarItensNota(itemNota);
                return Ok(itemNotaSalvo);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("/ItensNota/{itemNota}")]
        public IActionResult GetById(int itemNota) {
            try {
                var itensNota = _itensNotaService.GetById(itemNota);
                if (itensNota == null) {
                    return StatusCode(404, "Nenhum Usuario Encontrado com Esse Codigo");
                }
                return Ok(itensNota);
                }
            catch (Exception) {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPut("{itemNota}")]
        public async Task<IActionResult> Update(int itemNota, [FromBody] ItensNotaPostDTO itensNotaPostDTO) 
        {
            var updatedItensNota = await _itensNotaService.Update(itensNotaPostDTO);
            return Ok(updatedItensNota);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var deletedItemNota = await _itensNotaService.Delete(id);
            if (deletedItemNota == null) {
                return NotFound("Item Nota não encontrado.");
            }
            return Ok(deletedItemNota);
        }
    }
}
