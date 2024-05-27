using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories {
    public class RequisicaoRepository : IRequisicaoRepository {
        private readonly xAlmoxarifadoContext _context;

        public RequisicaoRepository(xAlmoxarifadoContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Requisicao>> ObterTodasRequisicoes() 
        {
            return await _context.Requisicaos.ToListAsync();
        }

        public async Task<Requisicao> ObterRequisicaoPorId(int id)     
        {
            return await _context.Requisicaos.FindAsync(id);
        }
        public async Task<Requisicao> CriarRequisicao(Requisicao requisicao) 
        {
            _context.Requisicaos.Add(requisicao);
            await _context.SaveChangesAsync();
            return requisicao;
        }

        public async Task<Requisicao> AtualizarRequisicao(Requisicao requisicao) 
        {
            _context.Requisicaos.Update(requisicao);
            await _context.SaveChangesAsync();
            return requisicao;
        }

        public async Task<Requisicao> DeletarRequisicao(int id) 
        {
            var requisicao = await _context.Requisicaos.FindAsync(id);
            if (requisicao != null) {
                _context.Requisicaos.Remove(requisicao);
                await _context.SaveChangesAsync();
            }
            return requisicao;
        }
    }
}
