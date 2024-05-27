using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ItensNotaController : ControllerBase {

        private readonly ItensNotaService _itensNotaService;
        private readonly EstoqueService _estoqueService;
        public ItensNotaController(ItensNotaService itensNotaService, EstoqueService estoqueService) {
            _itensNotaService = itensNotaService;
            _estoqueService = estoqueService;
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
                var itensNota = _itensNotaService.ObterItemNotaPorId(itemNota);
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
                _estoqueService.AtualizarEstoqueAoEntrarNotaFiscal(new ItensNota 
                {
                    ItemNum = itemNotaSalvo.ItemNum,
                    IdPro = itemNotaSalvo.IdPro,
                    IdNota = itemNotaSalvo.IdNota,
                    IdSec = itemNotaSalvo.IdSec,
                    QtdPro = itemNotaSalvo.QtdPro,
                    PreUnit = itemNotaSalvo.PreUnit,
                    TotalItem = itemNotaSalvo.TotalItem,
                    EstLin = itemNotaSalvo.EstLin
                });
                return Ok(itemNotaSalvo);
            }
            catch (Exception) 
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPut("{itemNota}")]
        public IActionResult AtualizarItemNota(int itemNota, ItensNotaPutDTO novoItem) 
        {
            try {
                var itemNotaAtualizado = _itensNotaService.AtualizarItemNota(itemNota, novoItem);
                if (itemNotaAtualizado == null) {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }
                _estoqueService.AtualizarEstoqueAoEntrarNotaFiscal(new ItensNota {
                    ItemNum = itemNotaAtualizado.ItemNum,
                    IdPro = itemNotaAtualizado.IdPro,
                    IdNota = itemNotaAtualizado.IdNota,
                    IdSec = itemNotaAtualizado.IdSec,
                    QtdPro = itemNotaAtualizado.QtdPro,
                    PreUnit = itemNotaAtualizado.PreUnit,
                    TotalItem = itemNotaAtualizado.TotalItem,
                    EstLin = itemNotaAtualizado.EstLin
                });
                return Ok(itemNotaAtualizado);
            }
            catch (Exception) 
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpDelete("{itemNota}")]
        public IActionResult DeletarItemNota(int itemNota) 
        {
            try 
            {
                var itemNotaAtual = _itensNotaService.ObterItemNotaPorId(itemNota);
                if (itemNotaAtual == null) {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }

                var itemDeletado = _itensNotaService.DeletarItemNota(itemNotaAtual);
                if (itemDeletado == null) {
                    return StatusCode(404, "Ocorreu um erro ao excluir o item");
                }

                return Ok(itemDeletado);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
