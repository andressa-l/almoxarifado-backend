using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces {
    public interface IProdutoRepository {

        Task<IEnumerable<Produto>> GetAll();
        Produto ObterProdutoPorId(int id);

        Task<Produto> CriarProduto(Produto produto);

        Task<Produto> AtualizarProduto(Produto produto);

        Task<Produto> DeletarProduto(int id);


    }
}
