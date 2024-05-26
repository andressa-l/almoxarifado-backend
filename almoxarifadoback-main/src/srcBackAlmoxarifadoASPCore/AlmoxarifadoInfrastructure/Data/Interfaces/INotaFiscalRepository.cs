using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces {
    public interface INotaFiscalRepository 
    {
        List<NotaFiscal> ObterTodasNotasFiscais();
        NotaFiscal ObterNotaFiscalPorId(int idNota);
        NotaFiscal CriarNotaFiscal(NotaFiscal notaFiscal);
        NotaFiscal AtualizarNotaFiscal(NotaFiscal notaFiscal);
        NotaFiscal DeletarNotaFiscal(NotaFiscal notaFiscal);
    }
}
