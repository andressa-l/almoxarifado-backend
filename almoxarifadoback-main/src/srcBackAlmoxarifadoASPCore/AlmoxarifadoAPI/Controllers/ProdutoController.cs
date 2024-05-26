using Microsoft.AspNetCore.Mvc;
using AlmoxarifadoServices.DTO;
using System.Threading.Tasks;
using AlmoxarifadoServices;

namespace AlmoxarifadoAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService) {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdutoPostDTO produtoDTO) {
            var createdProduto = await _produtoService.Create(produtoDTO);
            return Ok(createdProduto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var deletedProduto = await _produtoService.Delete(id);
            if (deletedProduto == null) {
                return NotFound("Produto não encontrado.");
            }
            return Ok(deletedProduto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10) {
            var produtos = await _produtoService.GetAll();

            var produtosPag = produtos.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return Ok(produtosPag);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var produto = await _produtoService.GetById(id);
            if (produto == null) {
                return NotFound("Produto não encontrado.");
            }
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProdutoPostDTO produtoDTO) {
            var updatedProduto = await _produtoService.Update(id, produtoDTO);
            if (updatedProduto == null) {
                return NotFound("Produto não encontrado.");
            }
            return Ok(updatedProduto);
        }
    }
}
