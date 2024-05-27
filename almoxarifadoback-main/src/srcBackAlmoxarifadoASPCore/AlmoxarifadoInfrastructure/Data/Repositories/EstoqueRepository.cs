using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;

namespace AlmoxarifadoInfrastructure.Data.Repositories {
    public class EstoqueRepository : IEstoqueRepository 
    {
        private readonly xAlmoxarifadoContext _context;
        public EstoqueRepository(xAlmoxarifadoContext context) {
            _context = context;
        }

        public Estoque ObterEstoquePorProduto(int idProduto) {
            return _context.Estoques.FirstOrDefault(e => e.IdPro == idProduto);
        }

        public void AtualizarEstoque(Estoque estoque) {
            _context.Estoques.Update(estoque);
            _context.SaveChanges();
        }

        public void CriarEstoque(Estoque estoque) {
            _context.Estoques.Add(estoque);
            _context.SaveChanges();
        }

        public List<Estoque> ObterTodosOsProdutosNoEstoque() {
            return _context.Estoques.ToList();
        }
    }
}
