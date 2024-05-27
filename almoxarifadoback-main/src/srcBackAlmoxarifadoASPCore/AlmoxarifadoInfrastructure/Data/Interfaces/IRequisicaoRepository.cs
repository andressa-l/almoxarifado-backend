using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces {
    public interface IRequisicaoRepository 
    {
        Task<IEnumerable<Requisicao>> ObterTodasRequisicoes();
        Task<Requisicao> ObterRequisicaoPorId(int id);
        Task<Requisicao> CriarRequisicao(Requisicao requisicao);
        Task<Requisicao> AtualizarRequisicao(Requisicao requisicao);
        Task<Requisicao> DeletarRequisicao(int id);
    }
}
