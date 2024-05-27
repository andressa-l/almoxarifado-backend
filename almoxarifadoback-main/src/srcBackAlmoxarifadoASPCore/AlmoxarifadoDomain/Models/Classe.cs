using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class Classe
    {
        public Classe()
        {
            Produtos = new HashSet<Produto>();
        }

        public int IdClas { get; set; }
        public int IdSubGru { get; set; }
        public string NomeCla { get; set; } = null!;

        public virtual Subgrupo IdSubGruNavigation { get; set; } = null!;
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
