using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces {
    public interface INotaFiscalRepository 
    {
        List<NotaFiscal> GetNotasFiscais();
        NotaFiscal CriarNotaFiscal(NotaFiscal notaFiscal);
        Task <NotaFiscal> GetById(int notaFiscal);
        Task <NotaFiscal> Update(NotaFiscal notaFiscal);
        Task <bool> Delete(int idNota);
    }
}
