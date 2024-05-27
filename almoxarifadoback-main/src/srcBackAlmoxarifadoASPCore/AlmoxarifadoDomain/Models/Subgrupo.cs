using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class Subgrupo
    {
        public Subgrupo()
        {
            Classes = new HashSet<Classe>();
        }

        public int IdSubGru { get; set; }
        public int IdGru { get; set; }
        public string? NomeSubGru { get; set; }

        public virtual Grupo IdGruNavigation { get; set; } = null!;
        public virtual ICollection<Classe> Classes { get; set; }
    }
}
