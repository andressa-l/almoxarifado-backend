using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces {
    public interface IItensNotaRepository 
    {
        List<ItensNota> ObterTodosItensNota();
        ItensNota ObterItemNotaPorId(int itemNota);
        ItensNota CriarItensNota(ItensNota itemNota);
        ItensNota AtualizarItemNota(ItensNota itemNota);
        ItensNota DeletarItemNota(int itemNota);
    }
}
