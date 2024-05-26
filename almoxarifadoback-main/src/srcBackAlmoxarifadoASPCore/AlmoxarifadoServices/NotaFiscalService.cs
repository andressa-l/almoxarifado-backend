using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;

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

        public List<NotaFiscalGetDTO> ObterTodasNotasFiscais() 
        {
            var mapper = _mapperConfiguration.CreateMapper();
            return mapper.Map<List<NotaFiscalGetDTO>>(_notaFiscalRepository.ObterTodasNotasFiscais());
        }

        public NotaFiscal ObterNotaFiscalPorId(int idNota) 
        {
            return _notaFiscalRepository.ObterNotaFiscalPorId(idNota);
        }

        public NotaFiscalGetDTO CriarNotaFiscal(NotaFiscalPostDTO notaFiscal) 
        {
            var notaFiscalSalva = _notaFiscalRepository.CriarNotaFiscal( 
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
                });

            return new NotaFiscalGetDTO 
            {
                IdNota = notaFiscalSalva.IdNota,
                IdFor = notaFiscalSalva.IdFor,
                IdSec = notaFiscalSalva.IdSec,
                DataNota = notaFiscalSalva.DataNota,
                NumNota = notaFiscalSalva.NumNota,
                ValorNota = notaFiscalSalva.ValorNota,
                QtdItem = notaFiscalSalva.QtdItem,
                Icms = notaFiscalSalva.Icms,
                Iss = notaFiscalSalva.Iss,
                Ano = notaFiscalSalva.Ano,
                Mes = notaFiscalSalva.Mes,
                IdTipoNota = notaFiscalSalva.IdTipoNota,
                ObservacaoNota = notaFiscalSalva.ObservacaoNota,
                EmpenhoNum = notaFiscalSalva.EmpenhoNum
            };
        }

        public NotaFiscalGetDTO AtualizarNotaFiscal(int idNota, NotaFiscalPutDTO novaNotaFiscal) {
            var notaAtual = _notaFiscalRepository.ObterNotaFiscalPorId(idNota);
            if (notaAtual != null) {
                notaAtual.IdFor = novaNotaFiscal.IdFor;
                notaAtual.IdSec = novaNotaFiscal.IdSec;
                notaAtual.NumNota = novaNotaFiscal.NumNota;
                notaAtual.DataNota = novaNotaFiscal.DataNota;
                notaAtual.ValorNota = novaNotaFiscal.ValorNota;
                notaAtual.QtdItem = novaNotaFiscal.QtdItem;
                notaAtual.Icms = novaNotaFiscal.Icms;
                notaAtual.Iss = novaNotaFiscal.Iss;
                notaAtual.Ano = novaNotaFiscal.Ano;
                notaAtual.Mes = novaNotaFiscal.Mes;
                notaAtual.IdTipoNota = novaNotaFiscal.IdTipoNota;
                notaAtual.ObservacaoNota = novaNotaFiscal.ObservacaoNota;
                notaAtual.EmpenhoNum = novaNotaFiscal.EmpenhoNum;

                _notaFiscalRepository.AtualizarNotaFiscal(notaAtual);

                var mapper = _mapperConfiguration.CreateMapper();
                return mapper.Map<NotaFiscalGetDTO>(notaAtual);
            }
            else {
                return null;
            }
        }

        public NotaFiscalGetDTO DeletarNotaFiscal(NotaFiscal notaFiscal) {
            var notaFiscalDeletada = _notaFiscalRepository.DeletarNotaFiscal(notaFiscal);
            if (notaFiscalDeletada != null) {
                var mapper = _mapperConfiguration.CreateMapper();
                return mapper.Map<NotaFiscalGetDTO>(notaFiscalDeletada);
            }
            return null;
        }
    }
}
