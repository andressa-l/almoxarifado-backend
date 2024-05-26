using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmoxarifadoServices {
    public class ItensReqService {
        private readonly IItensReqRepository _itensReqRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration mapperConfiguration;

        public ItensReqService(IItensReqRepository itensReqRepository) 
        {
            _itensReqRepository = itensReqRepository;
            mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ItensReqPostDTO, ItensReqGetDTO>();
                cfg.CreateMap<ItensReqGetDTO, ItensReqPostDTO>();
                cfg.CreateMap<ItensReq, ItensReqGetDTO>();
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        public List<ItensReqGetDTO> ObterTodosItensReq() 
        {
            var mapper = mapperConfiguration.CreateMapper();
            return mapper.Map<List<ItensReqGetDTO>>(_itensReqRepository.ObterTodosItensReq());
        }

        public ItensReq ObterItemRequisicaoPorId(int numItem) 
        {            
            return _itensReqRepository.ObterItemRequisicaoPorId(numItem);
        }

        public ItensReqGetDTO CriarItemRequisicao(ItensReqPostDTO itensReq) 
        {
            var itemReqSalvo = _itensReqRepository.CriarItemRequisicao(
                               new ItensReq {
                                   NumItem = itensReq.NumItem,
                                   IdPro = itensReq.IdPro,
                                   IdReq = itensReq.IdReq,
                                   IdSec = itensReq.IdSec,
                                   QtdPro = itensReq.QtdPro,
                                   PreUnit = itensReq.PreUnit,
                                   TotalItem = itensReq.TotalItem,
                                   TotalReal = itensReq.TotalReal
                               });
            return new ItensReqGetDTO 
            {
                NumItem = itemReqSalvo.NumItem,
                IdPro = itemReqSalvo.IdPro,
                IdReq = itemReqSalvo.IdReq,
                IdSec = itemReqSalvo.IdSec,
                QtdPro = itemReqSalvo.QtdPro,
                PreUnit = itemReqSalvo.PreUnit,
                TotalItem = itemReqSalvo.TotalItem,
                TotalReal = itemReqSalvo.TotalReal
            };
        }

        public ItensReqGetDTO AtualizarItemRequisicao(int numeroItem, ItensRequisicaoPutDTO itemReqNovo) 
        {
            var itemReqAtual = _itensReqRepository.ObterItemRequisicaoPorId(numeroItem);
            if (itemReqAtual != null) 
            {
                itemReqAtual.IdPro = itemReqNovo.IdPro;
                itemReqAtual.IdReq = itemReqNovo.IdReq;
                itemReqAtual.IdSec = itemReqNovo.IdSec;
                itemReqAtual.QtdPro = itemReqNovo.QtdPro;
                itemReqAtual.PreUnit = itemReqNovo.PreUnit;
                itemReqAtual.TotalItem = itemReqNovo.TotalItem;
                itemReqAtual.TotalReal = itemReqNovo.TotalReal;
                _itensReqRepository.AtualizarItemRequisicao(itemReqAtual);
                var mapper = mapperConfiguration.CreateMapper();
                return mapper.Map<ItensReqGetDTO>(itemReqAtual);
            }
            else {
                return null;
            }
        }

        public ItensReqGetDTO DeletarItemRequisicao(ItensReq itensReq) {
            var itemReqDeletado = _itensReqRepository.DeletarItemRequisicao(itensReq);
            if (itemReqDeletado != null ) {
                var mapper = mapperConfiguration.CreateMapper();
                return mapper.Map<ItensReqGetDTO>(itemReqDeletado);
            }
            return null;
        }
    }
}
