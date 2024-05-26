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
                var itensNota = _itensNotaService.ObterTodosItensNota();
                return Ok(itensNota);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("/ItensNota/{itemNota}")]
        public IActionResult GetById(int itemNota) 
        {
            try 
            {
                var itensNota = _itensNotaService.ObterItemNotaId(itemNota);
                if (itensNota == null) 
                {
                    return StatusCode(404, "Nenhum Usuario Encontrado com Esse Codigo");
                }
                return Ok(itensNota);
            }
            catch (Exception) 
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult CriarItensNota(ItensNotaPostDTO itemNota) 
        {
            try 
            {
                var itemNotaSalvo = _itensNotaService.CriarItemNota(itemNota);
                return Ok(itemNotaSalvo);
            }
            catch (Exception) 
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }



        [HttpPut("{itemNota}")]
        public async Task<IActionResult> AtualizarItemNota(int itemNota, [FromBody] ItensNotaPutDTO novoItem) 
        {
            try {
                var itemNotaAtualizado = await _itensNotaService.AtualizarItemNota(itemNota, novoItem);
                if (itemNotaAtualizado == null) {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }
                return Ok(itemNotaAtualizado);
            }
            catch (Exception) 
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpDelete("{itemNota}")]
        public async Task<IActionResult> DeletarItemNota(int itemNota) 
        {
            try 
            {
                var itemNotaDeletado = await _itensNotaService.DeletarItemNota(itemNota);
                if (itemNotaDeletado == null) {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }
                return Ok(itemNotaDeletado);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
