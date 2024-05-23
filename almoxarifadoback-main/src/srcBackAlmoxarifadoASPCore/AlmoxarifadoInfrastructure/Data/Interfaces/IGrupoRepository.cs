using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IGrupoRepository
    {
        List<Grupo> ObterTodosGrupos();
        Grupo ObterGrupoPorId(int id);

        Grupo CriarGrupo(Grupo grupo);
    }
}
