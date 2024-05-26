using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO
{
    public class GrupoPostDTO
    {
        public string NomeGru { get; set; } = null!;
        public string? SugestaoGru { get; set; }
    }

    public class GrupoGetDTO
    {
        public int IdGru { get; set; }
        public string NomeGru { get; set; } = null!;
        public string? SugestaoGru { get; set; }
    }
}
