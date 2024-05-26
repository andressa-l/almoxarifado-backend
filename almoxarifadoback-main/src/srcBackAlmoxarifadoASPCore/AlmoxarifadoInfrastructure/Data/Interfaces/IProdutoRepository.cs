using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces {
    public interface IProdutoRepository {

        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(int id);

        Task<Produto> Create(Produto produto);

        Task<Produto> Update(Produto produto);

        Task<Produto> Delete(int id);


    }
}
