using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;

namespace AlmoxarifadoServices {
    public class RequisicaoService  {
        private readonly IRequisicaoRepository _requisicaoRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration mapperConfiguration;


        public RequisicaoService(IRequisicaoRepository requisicaoRepository) {
            _requisicaoRepository = requisicaoRepository;
            mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<RequisicaoPostDTO, RequisicaoGetDTO>();
                cfg.CreateMap<RequisicaoPostDTO, Requisicao>();
                cfg.CreateMap<RequisicaoGetDTO, RequisicaoPostDTO>();
                cfg.CreateMap<Requisicao, RequisicaoGetDTO>();
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        public async Task<IEnumerable<RequisicaoGetDTO>> GetAll() 
        {
            try {
                var requisicoes = await _requisicaoRepository.ObterTodasRequisicoes();
                return _mapper.Map<IEnumerable<RequisicaoGetDTO>>(requisicoes);
            }
            catch (System.Exception) {
                return null;
            }
        }

        public async Task<RequisicaoGetDTO> GetById(int id) 
        {   
            try {
                var requisicao = await _requisicaoRepository.ObterRequisicaoPorId(id);
                return _mapper.Map<RequisicaoGetDTO>(requisicao);
            }
            catch (System.Exception) {
                return null;
            }
        }

        public async Task<RequisicaoGetDTO> Create(RequisicaoPostDTO requisicao) 
        {
            try {
                var requisicaoEntity = new Requisicao {
                    Ano = requisicao.Ano,
                    DataReq = DateTime.Now,
                    IdCli = requisicao.IdCli,
                    IdSec = requisicao.IdSec,
                    IdSet = requisicao.IdSet,
                    Mes = requisicao.Mes,
                    Observacao = requisicao.Observacao,
                    QtdIten = 0,
                    TotalReq = 0
                };
                var createdRequisicao = await _requisicaoRepository.CriarRequisicao(requisicaoEntity);
                return _mapper.Map<RequisicaoGetDTO>(createdRequisicao);
            }
            catch (System.Exception) {
                return null;
            }
        }

        public async Task<RequisicaoGetDTO> Update(int id, RequisicaoPutDTO requisicaoNova) 
        {
            try {
                var requisicaoAtual = await _requisicaoRepository.ObterRequisicaoPorId(id);
                requisicaoAtual.Ano = requisicaoNova.Ano;
                requisicaoAtual.DataReq = requisicaoNova.DataReq;
                requisicaoAtual.IdCli = requisicaoNova.IdCli;
                requisicaoAtual.IdSec = requisicaoNova.IdSec;
                requisicaoAtual.IdSet = requisicaoNova.IdSet;
                requisicaoAtual.Mes = requisicaoNova.Mes;
                requisicaoAtual.Observacao = requisicaoNova.Observacao;
                requisicaoAtual.QtdIten = requisicaoNova.QtdIten;
                requisicaoAtual.TotalReq = requisicaoNova.TotalReq;
                var updatedRequisicao = await _requisicaoRepository.AtualizarRequisicao(requisicaoAtual);
                return _mapper.Map<RequisicaoGetDTO>(updatedRequisicao);
            }
            catch (System.Exception) {
                return null;
            }
        }

        public async Task<bool> Delete(int id) 
        {
            try {
                var deleted = await _requisicaoRepository.DeletarRequisicao(id);
                return deleted != null;
            }
            catch (System.Exception) {
                return false;
            }
        }
    }
}
