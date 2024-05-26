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

        public ItensReqService(IItensReqRepository itensReqRepository) {
            _itensReqRepository = itensReqRepository;
            mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ItensReqPostDTO, ItensReqGetDTO>();
                cfg.CreateMap<ItensReqGetDTO, ItensReqPostDTO>();
                cfg.CreateMap<ItensReq, ItensReqGetDTO>();
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        public async Task<IEnumerable<ItensReqGetDTO>> GetAll() {
            var itensReqs = await _itensReqRepository.GetAll();
            return _mapper.Map<IEnumerable<ItensReqGetDTO>>(itensReqs);
        }

        public async Task<ItensReqGetDTO> GetById(int numItem) {
            var itensReq = await _itensReqRepository.GetById(numItem);
            return _mapper.Map<ItensReqGetDTO>(itensReq);
        }

        public async Task<ItensReqGetDTO> Create(ItensReqPostDTO itensReqPostDTO) {
            var itensReq = _mapper.Map<ItensReq>(itensReqPostDTO);
            var createdItensReq = await _itensReqRepository.Create(itensReq);
            return _mapper.Map<ItensReqGetDTO>(createdItensReq);
        }

        public async Task<ItensReqGetDTO> Update(ItensReqPostDTO itensReqPostDTO) {
            var itensReq = _mapper.Map<ItensReq>(itensReqPostDTO);
            var updatedItensReq = await _itensReqRepository.Update(itensReq);
            return _mapper.Map<ItensReqGetDTO>(updatedItensReq);
        }

        public async Task<bool> Delete(int numItem) {
            return await _itensReqRepository.Delete(numItem);
        }
    }
}
