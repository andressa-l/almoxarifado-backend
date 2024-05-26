using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces {
    public interface IItensNotaRepository 
    {
        List<ItensNota> GetItensNota();
        ItensNota CriarItensNota(ItensNota itemNota);
        ItensNota GetById(int itemNota);
        //Task<ItensNota> GetById(int itemNota);
        Task<ItensNota> Update(ItensNota itemNota);
        Task<bool> Delete(int itemNota);


        //Task<IEnumerable<ItensNota>> GetAll();
    }
}
