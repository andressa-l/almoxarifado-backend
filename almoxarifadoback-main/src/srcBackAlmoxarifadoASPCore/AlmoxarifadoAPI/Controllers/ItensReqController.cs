using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmoxarifadoAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ItensReqController : ControllerBase {
        private readonly ItensReqService _itensReqService;

        public ItensReqController(ItensReqService itensReqService) {
            _itensReqService = itensReqService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10) {
            var itensReqs = await _itensReqService.GetAll();
            var pagedItensReqs = itensReqs.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return Ok(pagedItensReqs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int numItem) {
            var itensReq = await _itensReqService.GetById(numItem);
            if (itensReq == null) {
                return NotFound();
            }
            return Ok(itensReq);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ItensReqPostDTO itensReqPostDTO) {
            var itensReq = await _itensReqService.Create(itensReqPostDTO);
            return CreatedAtAction(nameof(GetById), new { numItem = itensReq.NumItem }, itensReq);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int numItem, [FromBody] ItensReqPostDTO itensReqPostDTO) {
        

            var updatedItensReq = await _itensReqService.Update(itensReqPostDTO);
            return Ok(updatedItensReq);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int numItem) {
            var deleted = await _itensReqService.Delete(numItem);
            if (!deleted) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
