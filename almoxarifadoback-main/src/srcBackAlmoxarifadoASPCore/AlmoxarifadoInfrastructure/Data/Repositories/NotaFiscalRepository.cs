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

        public List<NotaFiscal> ObterTodasNotasFiscais() {
            return _context.NotaFiscals.Select(notasFiscais => new NotaFiscal {
                IdNota = notasFiscais.IdNota,
                IdFor = notasFiscais.IdFor ?? 0,
                IdSec = notasFiscais.IdSec,
                NumNota = notasFiscais.NumNota,
                DataNota = notasFiscais.DataNota ?? null,
                ValorNota = notasFiscais.ValorNota,
                QtdItem = notasFiscais.QtdItem,
                Icms = notasFiscais.Icms ?? 0,
                Iss = notasFiscais.Iss ?? 0,
                Ano = notasFiscais.Ano,
                Mes = notasFiscais.Mes ?? 0,
                IdTipoNota = notasFiscais.IdTipoNota,
                EmpenhoNum = notasFiscais.EmpenhoNum ?? 0,
                ObservacaoNota = notasFiscais.ObservacaoNota ?? "",
            }).ToList();
        }

        public NotaFiscal CriarNotaFiscal(NotaFiscal notaFiscal) 
        {            
            _context.NotaFiscals.Add(notaFiscal);
            _context.SaveChanges();
            return notaFiscal;
        }

        public NotaFiscal ObterNotaFiscalPorId(int idNota) 
        {
            return _context.NotaFiscals
                .Select(notas => new NotaFiscal {
                    IdNota = notas.IdNota,
                    IdFor = notas.IdFor ?? 0,
                    IdSec = notas.IdSec,
                    NumNota = notas.NumNota,
                    DataNota = notas.DataNota ?? null,
                    ValorNota = notas.ValorNota,
                    QtdItem = notas.QtdItem,
                    Icms = notas.Icms ?? 0,
                    Iss = notas.Iss ?? 0,
                    Ano = notas.Ano,
                    Mes = notas.Mes ?? 0,
                    IdTipoNota = notas.IdTipoNota,
                    EmpenhoNum = notas.EmpenhoNum ?? 0,
                    ObservacaoNota = notas.ObservacaoNota ?? "",
                })
                .ToList().First(x => x?.IdNota == idNota);
        }

        public NotaFiscal AtualizarNotaFiscal(NotaFiscal notaFiscal) {
            var notaFiscalAtual = _context.NotaFiscals.FirstOrDefault(x => x.IdNota == notaFiscal.IdNota);
            if (notaFiscalAtual != null) {
                notaFiscalAtual.IdFor = notaFiscal.IdFor;
                notaFiscalAtual.IdSec = notaFiscal.IdSec;
                notaFiscalAtual.NumNota = notaFiscal.NumNota;
                notaFiscalAtual.DataNota = notaFiscal.DataNota;
                notaFiscalAtual.ValorNota = notaFiscal.ValorNota;
                notaFiscalAtual.QtdItem = notaFiscal.QtdItem;
                notaFiscalAtual.Icms = notaFiscal.Icms;
                notaFiscalAtual.Iss = notaFiscal.Iss;
                notaFiscalAtual.Ano = notaFiscal.Ano;
                notaFiscalAtual.Mes = notaFiscal.Mes;
                notaFiscalAtual.IdTipoNota = notaFiscal.IdTipoNota;
                notaFiscalAtual.EmpenhoNum = notaFiscal.EmpenhoNum;
                notaFiscalAtual.ObservacaoNota = notaFiscal.ObservacaoNota;
                _context.SaveChanges();
            }
            return notaFiscalAtual;
        }

        public NotaFiscal DeletarNotaFiscal(NotaFiscal notaFiscal) {
            _context.NotaFiscals.Remove(notaFiscal);
            _context.SaveChanges();
            return notaFiscal;
        }
    }
}
