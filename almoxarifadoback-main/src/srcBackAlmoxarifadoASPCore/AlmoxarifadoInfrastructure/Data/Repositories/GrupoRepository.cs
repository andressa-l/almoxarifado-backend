using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class GrupoRepository : IGrupoRepository
    {
        private readonly ContextSQL _context;

        public GrupoRepository(ContextSQL pContext)
        {
            _context = pContext;
        }

        public List<Grupo> ObterTodosGrupos()
        {
            return _context.Grupo
                    .Select(g => new Grupo
                    {
                        ID_GRU = g.ID_GRU,
                        NOME_GRU = g.NOME_GRU,
                         SUGESTAO_GRU = g.SUGESTAO_GRU ?? "" 
                    })
                    .ToList();
        }

        public Grupo ObterGrupoPorId(int id)
        {
            return _context.Grupo
                   .Select(g => new Grupo
                   {
                       ID_GRU = g.ID_GRU,
                       NOME_GRU = g.NOME_GRU,
                       SUGESTAO_GRU = g.SUGESTAO_GRU ?? ""
                   })
                   .ToList().First(x => x?.ID_GRU == id);
        }

        public Grupo CriarGrupo(Grupo grupo)
        {
            _context.Grupo.Add(grupo);
            _context.SaveChanges();

            return grupo;
        }
    }
}
