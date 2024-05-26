using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories {
    public class ProdutoRepository : IProdutoRepository {
        private readonly xAlmoxarifadoContext _xAlmoxarifadoContext;

        public ProdutoRepository(xAlmoxarifadoContext context) {
            _xAlmoxarifadoContext = context;
        }

        public async Task<Produto> Create(Produto produto) {
            _xAlmoxarifadoContext.Produtos.Add(produto);
            await _xAlmoxarifadoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Delete(int id) {
            var produto = await _xAlmoxarifadoContext.Produtos.FindAsync(id);
            if (produto == null) {
                return null;
            }

            _xAlmoxarifadoContext.Produtos.Remove(produto);
            await _xAlmoxarifadoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<IEnumerable<Produto>> GetAll() {
            return await _xAlmoxarifadoContext.Produtos.ToListAsync();
        }

        public async Task<Produto> GetById(int id) {
            return await _xAlmoxarifadoContext.Produtos.FindAsync(id);
        }

        public async Task<Produto> Update(Produto produto) {
            _xAlmoxarifadoContext.Entry(produto).State = EntityState.Modified;
            try {
                await _xAlmoxarifadoContext.SaveChangesAsync();
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
            return _xAlmoxarifadoContext.Produtos.Any(e => e.IdPro == id);
        }
    }
}
