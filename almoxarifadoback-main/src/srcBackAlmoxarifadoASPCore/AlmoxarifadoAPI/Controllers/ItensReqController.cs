using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmoxarifadoAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ItensReqController : ControllerBase 
    {
        private readonly ItensReqService _itensReqService;
        private readonly EstoqueService _estoqueService;
        public ItensReqController(ItensReqService itensReqService, EstoqueService estoqueService) {
            _itensReqService = itensReqService;
            _estoqueService = estoqueService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10) 
        {
            try 
            {
                var itensReqs = _itensReqService.ObterTodosItensReq();
                var pagedItensReqs = itensReqs.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                return Ok(pagedItensReqs);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("{numItem}")]
        public IActionResult GetById(int numItem) 
        {
            try 
            {
                var itensReq = _itensReqService.ObterItemRequisicaoPorId(numItem);
                if (itensReq == null) {
                    return NotFound();
                }
                return Ok(itensReq);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult Create(ItensReqPostDTO itensReq) 
        {
            try {
                var itemReqSalvo = _itensReqService.CriarItemRequisicao(itensReq);
                _estoqueService.AtualizarEstoqueAoSairRequisicao(new ItensReq {
                    NumItem = itemReqSalvo.NumItem,
                    IdPro = itemReqSalvo.IdPro,
                    IdReq = itemReqSalvo.IdReq,
                    IdSec = itemReqSalvo.IdSec,
                    QtdPro = itemReqSalvo.QtdPro,
                    PreUnit = itemReqSalvo.PreUnit,
                    TotalItem = itemReqSalvo.TotalItem,
                    TotalReal = itemReqSalvo.TotalReal
                });
                return CreatedAtAction(nameof(GetById), new { numItem = itemReqSalvo.NumItem }, itemReqSalvo);
            }
            catch (Exception) 
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPut("{numItem}")]
        public IActionResult Update(int numItem, ItensRequisicaoPutDTO itensReqNovo) 
        {
            try 
            {
                var updatedItensReq = _itensReqService.AtualizarItemRequisicao(numItem, itensReqNovo);
                if (updatedItensReq == null) {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }
                _estoqueService.AtualizarEstoqueAoSairRequisicao(new ItensReq {
                    NumItem = updatedItensReq.NumItem,
                    IdPro = updatedItensReq.IdPro,
                    IdReq = updatedItensReq.IdReq,
                    IdSec = updatedItensReq.IdSec,
                    QtdPro = updatedItensReq.QtdPro,
                    PreUnit = updatedItensReq.PreUnit,
                    TotalItem = updatedItensReq.TotalItem,
                    TotalReal = updatedItensReq.TotalReal
                });
                return Ok(updatedItensReq);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpDelete("{numItem}")]
        public IActionResult Delete(int numItem) 
        {
            try {
                var itemReq = _itensReqService.ObterItemRequisicaoPorId(numItem);
                if (itemReq == null) {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }

                var itemReqDeletado = _itensReqService.DeletarItemRequisicao(itemReq);
                if (itemReqDeletado == null) {
                    return StatusCode(404, "Ocorreu um erro ao excluir o item");
                }

                return Ok(itemReqDeletado);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
