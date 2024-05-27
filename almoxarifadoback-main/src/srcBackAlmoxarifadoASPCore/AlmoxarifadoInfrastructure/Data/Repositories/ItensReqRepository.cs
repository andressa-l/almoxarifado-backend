using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories {
    public class ItensReqRepository : IItensReqRepository 
    {
        private readonly xAlmoxarifadoContext _context;
        public ItensReqRepository(xAlmoxarifadoContext context) {
            _context = context;
        }

        public List<ItensReq> ObterTodosItensReq() 
        {
            return _context.ItensReqs.Select(itemReq => new ItensReq 
            {
                NumItem = itemReq.NumItem,
                IdPro = itemReq.IdPro,
                IdReq = itemReq.IdReq,
                IdSec = itemReq.IdSec,
                QtdPro = itemReq.QtdPro,
                PreUnit = itemReq.PreUnit,
                TotalItem = itemReq.TotalItem,
                TotalReal = itemReq.TotalReal
            }).ToList();
            
        }

        public ItensReq ObterItemRequisicaoPorId(int numeroItem) 
        {
            return _context.ItensReqs
                .Select(itemReq => new ItensReq {
                    NumItem = itemReq.NumItem,
                    IdPro = itemReq.IdPro,
                    IdReq = itemReq.IdReq,
                    IdSec = itemReq.IdSec,
                    QtdPro = itemReq.QtdPro,
                    PreUnit = itemReq.PreUnit,
                    TotalItem = itemReq.TotalItem,
                    TotalReal = itemReq.TotalReal
                })
                .ToList().First(item => item?.NumItem == numeroItem);
        }

        public ItensReq CriarItemRequisicao(ItensReq itensReq) {
            _context.ItensReqs.Add(itensReq);
            _context.SaveChanges();
            return itensReq;
        }

        public ItensReq AtualizarItemRequisicao(ItensReq itensReq) 
        {
            var itemReqAtual = _context.ItensReqs.FirstOrDefault(x => x.IdReq == itensReq.IdReq);
            if (itemReqAtual != null) {
                itemReqAtual.IdPro = itensReq.IdPro;
                itemReqAtual.IdReq = itensReq.IdReq;
                itemReqAtual.IdSec = itensReq.IdSec;
                itemReqAtual.QtdPro = itensReq.QtdPro;
                itemReqAtual.PreUnit = itensReq.PreUnit;
                itemReqAtual.TotalItem = itensReq.TotalItem;
                itemReqAtual.TotalReal = itensReq.TotalReal;
                _context.SaveChanges();
                return itemReqAtual;
            }
            else {
                throw new InvalidOperationException("Item da Requisição não encontrado");
            }
        }

        public ItensReq DeletarItemRequisicao(ItensReq itensReq) 
        {
            _context.ItensReqs.Remove(itensReq);
            _context.SaveChanges();
            return itensReq;
        }
    }
}
