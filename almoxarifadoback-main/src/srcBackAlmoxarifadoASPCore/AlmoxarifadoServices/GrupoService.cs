using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;

namespace AlmoxarifadoServices {
    public class GrupoService
    {
        private readonly IGrupoRepository _grupoRepository;
        private readonly MapperConfiguration configurationMapper;

        public GrupoService(IGrupoRepository pGrupoRepository)
        {
            _grupoRepository = pGrupoRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Grupo, GrupoGetDTO>();
                cfg.CreateMap<GrupoGetDTO, Grupo>();
            });
        }

        public List<GrupoGetDTO> ObterTodosGrupos()
        {
            var mapper = configurationMapper.CreateMapper();
            return  mapper.Map<List<GrupoGetDTO>>(_grupoRepository.ObterTodosGrupos());
        }

        public Grupo ObterGrupoPorID(int id)
        {
            return _grupoRepository.ObterGrupoPorId(id);
        }

        public GrupoGetDTO CriarGrupo(GrupoPostDTO grupo)
        {
           var grupoSalvo = _grupoRepository.CriarGrupo(
                new Grupo { NomeGru = grupo.NomeGru, SugestaoGru = grupo.SugestaoGru}
             );

            return new GrupoGetDTO 
            { 
                IdGru = grupoSalvo.IdGru,
                NomeGru = grupoSalvo.NomeGru,
                SugestaoGru = grupoSalvo.SugestaoGru 
            };
        }

        //public object AtualizarGrupo(int id, GrupoPostDTO grupo) {

        //    var grupoExistente = _grupoRepository.ObterGrupoPorId(id);

        //    if (grupoExistente == null) {
        //        return null; 
        //    }

        //    grupoExistente.NOME_GRU = grupo.NOME_GRU;
        //    grupoExistente.SUGESTAO_GRU = grupo.SUGESTAO_GRU;

        //    _grupoRepository.AtualizarGrupo(grupoExistente);

        //    return new GrupoGetDTO {
        //        ID_GRU = grupoExistente.ID_GRU,
        //        NOME_GRU = grupoExistente.NOME_GRU,
        //        SUGESTAO_GRU = grupoExistente.SUGESTAO_GRU
        //    };
        //}

        // AQUI PAREI

        //public void ExcluirGrupo(int id) {
        //    var grupoExistente = _grupoRepository.ObterGrupoPorId(id);
        //    if (grupoExistente == null) {
        //        throw new Exception("Grupo não encontrado."); 
        //    }

        //    _grupoRepository.ExcluirGrupo(grupoExistente);
        //}

        //public void AtualizarEstoque(int idGrupo, int quantidade) {
        //    var grupo = _grupoRepository.ObterGrupoPorId(idGrupo);
        //    if (grupo != null) {
        //        // Atualizar a quantidade em estoque
        //        grupo.Quantidade += quantidade;
        //        _grupoRepository.AtualizarGrupo(grupo);
        //    }
        //    else {
        //        throw new Exception("Grupo não encontrado.");
        //    }
        //}

        //public bool VerificarDisponibilidadeEstoque(int idGrupo, int quantidadeSolicitada) {
        //    var grupo = _grupoRepository.ObterGrupoPorId(idGrupo);
        //    if (grupo != null) {
        //        return grupo.Quantidade >= quantidadeSolicitada;
        //    }
        //    else {
        //        throw new Exception("Grupo não encontrado.");
        //    }
        //}

        //public void VerificarEstoqueMinimo(int idGrupo) {
        //    var grupo = _grupoRepository.ObterGrupoPorId(idGrupo);
        //    if (grupo != null) {
        //        if (grupo.Quantidade < grupo.EstoqueMinimo) {
        //            // Realizar ação para lidar com estoque abaixo do mínimo, como enviar uma notificação
        //            // Exemplo: NotificarResponsavelEstoqueMinimo(grupo);
        //        }
        //    }
        //    else {
        //        throw new Exception("Grupo não encontrado.");
        //    }
        //}

        //public object ObterTodosGrupos() {
        //    throw new NotImplementedException();
        //}
    }
}
