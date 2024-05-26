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

        public List<ItensNotaGetDTO> ObterTodosItensNota() {
            var mapper = _mapperConfiguration.CreateMapper();
            return mapper.Map<List<ItensNotaGetDTO>>(_itensNotaRepository.ObterTodosItensNota());
        }

        public ItensNota ObterItemNotaPorId(int itemNota) 
        {
            return _itensNotaRepository.ObterItemNotaPorId(itemNota);
        }

        public ItensNotaPostDTO CriarItemNota(ItensNotaPostDTO itemNota) 
        {
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

        public ItensNotaGetDTO AtualizarItemNota(int itemNota, ItensNotaPutDTO novoItemNota) {
            var itemAtual = _itensNotaRepository.ObterItemNotaPorId(itemNota);
            if (itemAtual != null) {
                itemAtual.IdPro = novoItemNota.IdPro;
                itemAtual.IdNota = novoItemNota.IdNota;
                itemAtual.IdSec = novoItemNota.IdSec;
                itemAtual.QtdPro = novoItemNota.QtdPro;
                itemAtual.PreUnit = novoItemNota.PreUnit;
                itemAtual.TotalItem = novoItemNota.TotalItem;
                itemAtual.EstLin = novoItemNota.EstLin;

                _itensNotaRepository.AtualizarItemNota(itemAtual);

                var mapper = _mapperConfiguration.CreateMapper();
                return mapper.Map<ItensNotaGetDTO>(itemAtual);
            }
            else {
                return null;
            }
        }

        public async Task<ItensNotaGetDTO> DeletarItemNota(int itemNota) {
            var deletedItensNota = await _itensNotaRepository.DeletarItemNota(itemNota);
            return _mapper.Map<ItensNotaGetDTO>(deletedItensNota);
        }
    }
}
