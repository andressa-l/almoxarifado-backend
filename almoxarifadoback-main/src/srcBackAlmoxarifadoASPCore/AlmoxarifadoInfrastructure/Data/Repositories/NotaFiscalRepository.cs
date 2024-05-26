using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories {
    public class NotaFiscalRepository : INotaFiscalRepository 
    {
        private readonly xAlmoxarifadoContext _context;

        public NotaFiscalRepository(xAlmoxarifadoContext context) {
            _context = context;
        }

        public List<NotaFiscal> GetNotasFiscais() {
            return _context.NotaFiscals.Select(n => new NotaFiscal {
                IdNota = n.IdNota,
                IdFor = n.IdFor ?? 0,
                IdSec = n.IdSec,
                NumNota = n.NumNota,
                DataNota = n.DataNota ?? null,
                ValorNota = n.ValorNota,
                QtdItem = n.QtdItem,
                Icms = n.Icms ?? 0,
                Iss = n.Iss ?? 0,
                Ano = n.Ano,
                Mes = n.Mes ?? 0,
                IdTipoNota = n.IdTipoNota,
                EmpenhoNum = n.EmpenhoNum ?? 0,
                ObservacaoNota = n.ObservacaoNota ?? "",
            }).ToList();
        }

        public NotaFiscal CriarNotaFiscal(NotaFiscal notaFiscal) 
        {            
            _context.NotaFiscals.Add(notaFiscal);
            _context.SaveChanges();
            return notaFiscal;
        }

        public NotaFiscal GetById(int notaFiscal) {
            return _context.NotaFiscals
                .Select(n => new NotaFiscal {
                    IdNota = n.IdNota,
                    IdFor = n.IdFor ?? 0,
                    IdSec = n.IdSec,
                    NumNota = n.NumNota,
                    DataNota = n.DataNota ?? null,
                    ValorNota = n.ValorNota,
                    QtdItem = n.QtdItem,
                    Icms = n.Icms ?? 0,
                    Iss = n.Iss ?? 0,
                    Ano = n.Ano,
                    Mes = n.Mes ?? 0,
                    IdTipoNota = n.IdTipoNota,
                    EmpenhoNum = n.EmpenhoNum ?? 0,
                    ObservacaoNota = n.ObservacaoNota ?? "",
                })
                .ToList().First(x => x?.IdNota == notaFiscal);
        }

        public async Task<NotaFiscal> Update(NotaFiscal notaFiscal) {
            _context.NotaFiscals.Update(notaFiscal);
            await _context.SaveChangesAsync();
            return notaFiscal;
        }

        public async Task<bool> Delete(int notaFiscal) {
            var notasFiscal = await _context.NotaFiscals.FindAsync(notaFiscal);
            if (notasFiscal == null) {
                return false;
            }

            _context.NotaFiscals.Remove(notasFiscal);
            await _context.SaveChangesAsync();
            return true;
        }

        Task<NotaFiscal> INotaFiscalRepository.GetById(int notaFiscal) {
            throw new NotImplementedException();
        }
    }
}
