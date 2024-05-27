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

        public List<ItensNota> ObterTodosItensNota() 
        {
            return _context.ItensNota.Select(itemNota => new ItensNota 
            {
                ItemNum = itemNota.ItemNum,
                IdPro = itemNota.IdPro,
                IdNota = itemNota.IdNota,
                IdSec = itemNota.IdSec,
                QtdPro = itemNota.QtdPro,
                PreUnit = itemNota.PreUnit,
                TotalItem = itemNota.TotalItem,
                EstLin = itemNota.EstLin,
            }).ToList();
        }

        public ItensNota CriarItensNota(ItensNota itemNota) 
        {
            _context.ItensNota.Add(itemNota);
            _context.SaveChanges();
            return itemNota;
        }

        public ItensNota ObterItemNotaPorId(int itemNota) {
            
            return _context.ItensNota
                .Select(i => new ItensNota {
                    EstLin = i.EstLin,
                    IdNota = i.IdNota,
                    IdPro = i.IdPro,
                    IdSec = i.IdSec,
                    ItemNum = i.ItemNum,
                    PreUnit = i.PreUnit,
                    TotalItem = i.TotalItem,
                    QtdPro = i.QtdPro
                })
                .ToList().First(item => item.ItemNum == itemNota);
        }

        public ItensNota AtualizarItemNota(ItensNota itemNota) 
        {
            var itemNotaAtual = _context.ItensNota.FirstOrDefault(x => x.ItemNum == itemNota.ItemNum);
            if (itemNotaAtual != null) 
            {
                itemNotaAtual.EstLin = itemNota.EstLin;
                itemNotaAtual.IdNota = itemNota.IdNota;
                itemNotaAtual.IdPro = itemNota.IdPro;
                itemNotaAtual.IdSec = itemNota.IdSec;
                itemNotaAtual.PreUnit = itemNota.PreUnit;
                itemNotaAtual.TotalItem = itemNota.TotalItem;
                itemNotaAtual.QtdPro = itemNota.QtdPro;

                _context.SaveChanges();
                return itemNotaAtual;
            }
            else {
                throw new InvalidCastException("Item não encontrado");
            }
        }

        public ItensNota DeletarItemNota(ItensNota itemNota) 
        {
            _context.ItensNota.Remove(itemNota);
            _context.SaveChanges();
            return itemNota;
        }
    }
}
