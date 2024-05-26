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

        public async Task<IEnumerable<RequisicaoGetDTO>> GetAll() {
            var requisicoes = await _requisicaoRepository.GetAll();
            return _mapper.Map<IEnumerable<RequisicaoGetDTO>>(requisicoes);
        }

        public async Task<RequisicaoGetDTO> GetById(int id) {
            var requisicao = await _requisicaoRepository.GetById(id);
            return _mapper.Map<RequisicaoGetDTO>(requisicao);
        }

        public async Task<RequisicaoGetDTO> Create(RequisicaoPostDTO requisicao) {
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
            var createdRequisicao = await _requisicaoRepository.Create(requisicaoEntity);
            return _mapper.Map<RequisicaoGetDTO>(createdRequisicao);
        }

        public async Task<RequisicaoGetDTO> Update(RequisicaoPostDTO requisicao) {
            var requisicaoEntity = _mapper.Map<Requisicao>(requisicao);
            var updatedRequisicao = await _requisicaoRepository.Update(requisicaoEntity);
            return _mapper.Map<RequisicaoGetDTO>(updatedRequisicao);
        }

        public async Task<bool> Delete(int id) {
            var deleted = await _requisicaoRepository.Delete(id);
            return deleted != null;
        }
    }
}
