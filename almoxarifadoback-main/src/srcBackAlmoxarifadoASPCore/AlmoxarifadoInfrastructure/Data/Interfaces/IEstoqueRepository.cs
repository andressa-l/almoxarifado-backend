using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces {
    public interface IEstoqueRepository 
    {
        List<Estoque> ObterTodosOsProdutosNoEstoque();
        Estoque ObterEstoquePorProduto(int idProduto);
        void AtualizarEstoque(Estoque estoque);
        void CriarEstoque(Estoque estoque);
    }
}
