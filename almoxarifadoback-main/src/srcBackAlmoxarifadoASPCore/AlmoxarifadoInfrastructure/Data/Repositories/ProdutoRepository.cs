using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories {
    public class ProdutoRepository : IProdutoRepository {
        private readonly xAlmoxarifadoContext _context;

        public ProdutoRepository(xAlmoxarifadoContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll() {
            return await _context.Produtos.ToListAsync();
        }

        public Produto ObterProdutoPorId(int id) 
        {
            return _context.Produtos.FirstOrDefault(p => p.IdPro == id);
        }

        public async Task<Produto> CriarProduto(Produto produto) {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> DeletarProduto(int id) {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) {
                return null;
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }




        public async Task<Produto> AtualizarProduto(Produto produto) {
            _context.Entry(produto).State = EntityState.Modified;
            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!ProdutoExists(produto.IdPro)) {
                    return null;
                }
                else {
                    throw;
                }
            }
            return produto;
        }

        private bool ProdutoExists(int id) {
            return _context.Produtos.Any(e => e.IdPro == id);
        }
    }
}
