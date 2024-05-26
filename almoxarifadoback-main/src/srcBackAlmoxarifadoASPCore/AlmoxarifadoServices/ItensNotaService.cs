using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices {
    public class ItensNotaService 
    {
        private readonly IItensNotaRepository _itensNotaRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        public ItensNotaService(IItensNotaRepository itensNotaRepository) {
            _itensNotaRepository = itensNotaRepository;
            _mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ItensNota, ItensNotaGetDTO>();
                cfg.CreateMap<ItensNotaPostDTO, ItensNota>();
                cfg.CreateMap<ItensNotaGetDTO, ItensNotaPostDTO>();
            });
            _mapper = _mapperConfiguration.CreateMapper();
        }

        public List<ItensNotaGetDTO> GetItensNota() {
            var mapper = _mapperConfiguration.CreateMapper();
            return mapper.Map<List<ItensNotaGetDTO>>(_itensNotaRepository.GetItensNota());
        }

        public ItensNota GetById(int itemNota) 
        {
            return _itensNotaRepository.GetById(itemNota);
        }

        public ItensNotaPostDTO CriarItensNota(ItensNotaPostDTO itemNota) {
            var itemNotaSalvo = _itensNotaRepository.CriarItensNota(
                    new ItensNota {
                        EstLin = itemNota.EstLin,
                        IdNota = itemNota.IdNota,
                        IdPro = itemNota.IdPro,
                        IdSec = itemNota.IdSec,
                        ItemNum = itemNota.ItemNum,
                        PreUnit = itemNota.PreUnit,
                        QtdPro = itemNota.QtdPro
                    });

            return new ItensNotaPostDTO {
                EstLin = itemNotaSalvo.EstLin,
                IdNota = itemNotaSalvo.IdNota,
                IdPro = itemNotaSalvo.IdPro,
                IdSec = itemNotaSalvo.IdSec,
                ItemNum = itemNotaSalvo.ItemNum,
                PreUnit = itemNotaSalvo.PreUnit,
                QtdPro = itemNotaSalvo.QtdPro
            };
        }

        public async Task<ItensNotaGetDTO> Update(ItensNotaPostDTO itensNotaPostDTO) {
            var itensNota = _mapper.Map<ItensNota>(itensNotaPostDTO);
            var updatedItensNota = await _itensNotaRepository.Update(itensNota);
            return _mapper.Map<ItensNotaGetDTO>(updatedItensNota);
        }

        public async Task<ItensNotaGetDTO> Delete(int itemNota) {
            var deletedItensNota = await _itensNotaRepository.Delete(itemNota);
            return _mapper.Map<ItensNotaGetDTO>(deletedItensNota);
        }
    }
}
