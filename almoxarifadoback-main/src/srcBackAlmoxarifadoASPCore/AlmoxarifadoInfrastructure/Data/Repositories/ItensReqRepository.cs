using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories {
    public class ItensReqRepository : IItensReqRepository {
        private readonly xAlmoxarifadoContext _context;

        public ItensReqRepository(xAlmoxarifadoContext context) {
            _context = context;
        }

        public async Task<IEnumerable<ItensReq>> GetAll() {
            return await _context.ItensReqs.ToListAsync();
        }

        public async Task<ItensReq> GetById(int numItem) {
            return await _context.ItensReqs.FindAsync(numItem);
        }

        public async Task<ItensReq> Create(ItensReq itensReq) {
            _context.ItensReqs.Add(itensReq);
            await _context.SaveChangesAsync();
            return itensReq;
        }

        public async Task<ItensReq> Update(ItensReq itensReq) {
            _context.ItensReqs.Update(itensReq);
            await _context.SaveChangesAsync();
            return itensReq;
        }

        public async Task<bool> Delete(int numItem) {
            var itensReq = await _context.ItensReqs.FindAsync(numItem);
            if (itensReq == null) {
                return false;
            }

            _context.ItensReqs.Remove(itensReq);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
