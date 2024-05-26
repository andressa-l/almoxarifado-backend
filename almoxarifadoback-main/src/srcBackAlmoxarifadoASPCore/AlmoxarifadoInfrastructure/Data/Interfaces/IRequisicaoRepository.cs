using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces {
    public interface IRequisicaoRepository {
        Task<IEnumerable<Requisicao>> GetAll();
        Task<Requisicao> GetById(int id);
        Task<Requisicao> Create(Requisicao requisicao);
        Task<Requisicao> Update(Requisicao requisicao);
        Task<Requisicao> Delete(int id);
    }
}
