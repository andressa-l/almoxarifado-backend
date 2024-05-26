using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories {
    public class ItensNotaRepository : IItensNotaRepository
    {
        private readonly xAlmoxarifadoContext _context;

        public ItensNotaRepository(xAlmoxarifadoContext context) 
        {
            _context = context;
        }

        public List<ItensNota> GetItensNota() 
        {
            return _context.ItensNota.Select(i => new ItensNota {

                EstLin = i.EstLin,
                IdNota = i.IdNota,
                IdPro = i.IdPro,
                IdSec = i.IdSec,
                ItemNum = i.ItemNum,
                PreUnit = i.PreUnit,
                QtdPro = i.QtdPro
            }).ToList();
                
        }

        public ItensNota CriarItensNota(ItensNota itemNota) 
        {
            _context.ItensNota.Add(itemNota);
            _context.SaveChanges();
            return itemNota;
        }

        public ItensNota GetById(int itemNota) {
            
            return _context.ItensNota
                .Select(i => new ItensNota {
                    EstLin = i.EstLin,
                    IdNota = i.IdNota,
                    IdPro = i.IdPro,
                    IdSec = i.IdSec,
                    ItemNum = i.ItemNum,
                    PreUnit = i.PreUnit,
                    QtdPro = i.QtdPro
                })
                .ToList().First(x => x?.ItemNum == itemNota);
        }

        public async Task<ItensNota> Update(ItensNota itemNota) {
            _context.ItensNota.Update(itemNota);
            await _context.SaveChangesAsync();
            return itemNota;
        }

        public async Task<bool> Delete(int itemNota) {
            var itensNota = await _context.ItensNota.FindAsync(itemNota);
            if (itensNota == null) {
                return false;
            }

            _context.ItensNota.Remove(itensNota);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
