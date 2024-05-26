using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces {
    public interface IItensReqRepository {
        Task<IEnumerable<ItensReq>> GetAll();
        Task<ItensReq> GetById(int numItem);
        Task<ItensReq> Create(ItensReq itensReq);
        Task<ItensReq> Update(ItensReq itensReq);
        Task<bool> Delete(int numItem);
    }
}
