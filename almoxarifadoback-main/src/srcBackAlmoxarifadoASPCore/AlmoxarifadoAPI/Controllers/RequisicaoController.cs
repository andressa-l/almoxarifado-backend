using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmoxarifadoAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class RequisicaoController : ControllerBase {
        private readonly RequisicaoService _requisicaoService;

        public RequisicaoController(RequisicaoService requisicaoService) {
            _requisicaoService = requisicaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10) {
            var requisicoes = await _requisicaoService.GetAll();
            var pagedRequisicoes = requisicoes.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return Ok(pagedRequisicoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var requisicao = await _requisicaoService.GetById(id);
            if (requisicao == null) {
                return NotFound();
            }
            return Ok(requisicao);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequisicaoPostDTO requisicaoPostDTO) {
            var requisicao = await _requisicaoService.Create(requisicaoPostDTO);
            return CreatedAtAction(nameof(GetById), new { id = requisicao.IdReq }, requisicao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RequisicaoPostDTO requisicaoPostDTO) {
      

            var requisicao = await _requisicaoService.Update(requisicaoPostDTO);
            return Ok(requisicao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var deleted = await _requisicaoService.Delete(id);
            if (!deleted) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
