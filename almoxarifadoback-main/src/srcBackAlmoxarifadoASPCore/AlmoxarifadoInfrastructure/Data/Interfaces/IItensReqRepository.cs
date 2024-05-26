using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces {
    public interface IItensReqRepository {
        List<ItensReq> ObterTodosItensReq();
        ItensReq ObterItemRequisicaoPorId(int numeroItem);
        ItensReq CriarItemRequisicao(ItensReq itensReq);
        ItensReq AtualizarItemRequisicao(ItensReq itensReq);
        ItensReq DeletarItemRequisicao(ItensReq itensReq);
    }
}
