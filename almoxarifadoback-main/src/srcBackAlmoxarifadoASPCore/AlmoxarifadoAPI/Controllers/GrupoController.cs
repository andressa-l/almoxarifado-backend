using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupoController : ControllerBase
    {
        private readonly GrupoService _grupoService;
        public GrupoController(GrupoService grupoService)
        {
            _grupoService = grupoService;
        }

  
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var grupos = _grupoService.ObterTodosGrupos();
                return Ok(grupos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
         
        }

        [HttpGet("/Grupo/{id}")]
        public IActionResult GetPorID(int id)
        {
            try
            {
                var grupo = _grupoService.ObterGrupoPorID(id);
                if (grupo == null)
                {
                    return StatusCode(404, "Nenhum Usuario Encontrado com Esse Codigo");
                }
                return Ok(grupo);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }

        }

        [HttpPost]
        public IActionResult CriarGrupo(GrupoPostDTO grupo)
        {
            try
            {
                 var grupoSalvo = _grupoService.CriarGrupo(grupo);
                  return Ok(grupoSalvo);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        //[HttpPut("{id}")]
        //public IActionResult AtualizarGrupo(int id, GrupoPostDTO grupo) {
        //    try {
        //        var grupoAtualizado = _grupoService.AtualizarGrupo(id, grupo);
        //        if (grupoAtualizado == null) {
        //            return StatusCode(404, "Nenhum Grupo Encontrado com Esse ID");
        //        }
        //        return Ok(grupoAtualizado);
        //    }
        //    catch (Exception) {
        //        return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult ExcluirGrupo(int id) {
        //    try {
        //        _grupoService.ExcluirGrupo(id);
        //        return NoContent(); 
        //    }
        //    catch (Exception) {
        //        return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
        //    }
        //}

        //[HttpPost("entrada")]
        //public IActionResult RegistrarEntradaProduto(NotaFiscalDTO notaFiscal) {
        //    try {

        //        return Ok("Entrada de produtos registrada com sucesso");
        //    }
        //    catch (Exception ex) {
        //        return StatusCode(500, $"Erro ao registrar entrada de produtos: {ex.Message}");
        //    }
        //}

        //[HttpPost("saida")]
        //public IActionResult RegistrarSaidaProduto(RequisicaoDTO requisicao) {
        //    try {
        //        return Ok("Saída de produtos registrada com sucesso");
        //    }
        //    catch (Exception ex) {
        //        return StatusCode(500, $"Erro ao registrar saída de produtos: {ex.Message}");
        //    }
        //}

    }
}
