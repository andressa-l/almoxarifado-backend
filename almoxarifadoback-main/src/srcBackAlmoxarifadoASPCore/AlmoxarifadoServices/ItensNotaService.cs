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

        public ItensNotaGetDTO CriarItemNota(ItensNotaPostDTO itemNota) 
        {
            var itemNotaSalvo = _itensNotaRepository.CriarItensNota(
                    new ItensNota {
                        ItemNum = itemNota.ItemNum,
                        IdPro = itemNota.IdPro,
                        IdNota = itemNota.IdNota,
                        IdSec = itemNota.IdSec,
                        QtdPro = itemNota.QtdPro,
                        PreUnit = itemNota.PreUnit,
                        TotalItem = itemNota.QtdPro * itemNota.PreUnit,
                        EstLin = itemNota.EstLin,
                    });

            return new ItensNotaGetDTO {
                ItemNum = itemNotaSalvo.ItemNum,
                IdPro = itemNotaSalvo.IdPro,
                IdNota = itemNotaSalvo.IdNota,
                IdSec = itemNotaSalvo.IdSec,
                QtdPro = itemNotaSalvo.QtdPro,
                PreUnit = itemNotaSalvo.PreUnit,
                TotalItem = itemNotaSalvo.QtdPro * itemNota.PreUnit,
                EstLin = itemNotaSalvo.EstLin,
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
                itemAtual.TotalItem = novoItemNota.QtdPro * novoItemNota.PreUnit;
                itemAtual.EstLin = novoItemNota.EstLin;

                _itensNotaRepository.AtualizarItemNota(itemAtual);

                var mapper = _mapperConfiguration.CreateMapper();
                return mapper.Map<ItensNotaGetDTO>(itemAtual);
            }
            else {
                return null;
            }
        }

        public ItensNotaGetDTO DeletarItemNota(ItensNota itemNota) {
            var itemNotaDeletado = _itensNotaRepository.DeletarItemNota(itemNota);
            if (itemNotaDeletado != null) 
            {
                var mapper = _mapperConfiguration.CreateMapper();
                return mapper.Map<ItensNotaGetDTO>(itemNotaDeletado);
            }
            return null;
        }
    }
}
