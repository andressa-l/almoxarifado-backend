using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices 
{
    public class NotaFiscalService 
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository) 
        {
            _notaFiscalRepository = notaFiscalRepository;
            _mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<NotaFiscal, NotaFiscalGetDTO>();
                cfg.CreateMap<NotaFiscalPostDTO, NotaFiscal>();
                cfg.CreateMap<NotaFiscalGetDTO, NotaFiscalPostDTO>();
            });
            _mapper = _mapperConfiguration.CreateMapper();
        }

        public List<NotaFiscalGetDTO> GetNotasFiscais() 
        {
            var mapper = _mapperConfiguration.CreateMapper();
            return mapper.Map<List<NotaFiscalGetDTO>>(_notaFiscalRepository.GetNotasFiscais());
        }

        public NotaFiscalGetDTO GetById(int idNota) {
            var notaFiscal = _notaFiscalRepository.GetById(idNota);
            return _mapper.Map<NotaFiscalGetDTO>(notaFiscal);
        }

        public NotaFiscalGetDTO CriarNotaFiscal(NotaFiscalPostDTO notaFiscal) 
        {
            var notaFiscalMapper = _notaFiscalRepository.CriarNotaFiscal
                ( 
                new NotaFiscal
                { 
                    IdFor = notaFiscal.IdFor,
                    IdSec = notaFiscal.IdSec,
                    DataNota = DateTime.Now,
                    NumNota = notaFiscal.NumNota,
                    ValorNota = 0,
                    QtdItem = 0,
                    Icms = 0,
                    Iss = 0,
                    Ano = notaFiscal.Ano,
                    Mes = notaFiscal.Mes,
                    IdTipoNota = notaFiscal.IdTipoNota,
                    ObservacaoNota = notaFiscal.ObservacaoNota,
                    EmpenhoNum = 0
                }
                );

            return new NotaFiscalGetDTO 
            {
                IdNota = notaFiscalMapper.IdNota,
                IdFor = notaFiscalMapper.IdFor,
                IdSec = notaFiscalMapper.IdSec,
                DataNota = notaFiscalMapper.DataNota,
                NumNota = notaFiscalMapper.NumNota,
                ValorNota = notaFiscalMapper.ValorNota,
                QtdItem = notaFiscalMapper.QtdItem,
                Icms = notaFiscalMapper.Icms,
                Iss = notaFiscalMapper.Iss,
                Ano = notaFiscalMapper.Ano,
                Mes = notaFiscalMapper.Mes,
                IdTipoNota = notaFiscalMapper.IdTipoNota,
                ObservacaoNota = notaFiscalMapper.ObservacaoNota,
                EmpenhoNum = notaFiscalMapper.EmpenhoNum
            };
        }

        public async Task<NotaFiscalGetDTO> Update(NotaFiscalPostDTO notaFiscalPostDTO) {
            var notaFiscal = _mapper.Map<NotaFiscal>(notaFiscalPostDTO);
            var updatedNotaFiscal = await _notaFiscalRepository.Update(notaFiscal);
            return _mapper.Map<NotaFiscalGetDTO>(updatedNotaFiscal);
        }

        public async Task<NotaFiscalGetDTO> Delete(int idNota) {
            var deletedNotaFiscal = await _notaFiscalRepository.Delete(idNota);
            return _mapper.Map<NotaFiscalGetDTO>(deletedNotaFiscal);
        }
    }
}
