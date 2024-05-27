using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class UnidadeMedidum
    {
        public UnidadeMedidum()
        {
            Produtos = new HashSet<Produto>();
        }

        public int IdUnMed { get; set; }
        public string? NomeUnMed { get; set; }
        public string? Sigla { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
