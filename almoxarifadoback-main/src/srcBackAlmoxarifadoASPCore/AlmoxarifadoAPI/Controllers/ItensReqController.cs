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
        public ItensReqController(ItensReqService itensReqService) {
            _itensReqService = itensReqService;
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
        public IActionResult Create(ItensReqPostDTO itensReqPostDTO) 
        {
            try {
                var itensReq = _itensReqService.CriarItemRequisicao(itensReqPostDTO);
                return CreatedAtAction(nameof(GetById), new { numItem = itensReq.NumItem }, itensReq);
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
                return Ok(updatedItensReq);
            }
            catch (Exception) {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpDelete("{numItem}")]
        public IActionResult Delete(int numItem) 
        {
            
        }
    }
}
