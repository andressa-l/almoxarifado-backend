using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class Produto
    {
        public Produto()
        {
            ItensNota = new HashSet<ItensNota>();
            ItensReqs = new HashSet<ItensReq>();
        }

        public int IdPro { get; set; }
        public int IdClas { get; set; }
        public int IdUnMed { get; set; }
        public string Descricao { get; set; } = null!;
        public string? Observacao { get; set; }
        public int? EstoqueMin { get; set; }
        public bool? Perecivel { get; set; }
        public int? QtdEmbalagem { get; set; }

        public virtual Classe IdClasNavigation { get; set; } = null!;
        public virtual UnidadeMedidum IdUnMedNavigation { get; set; } = null!;
        public virtual ICollection<ItensNota> ItensNota { get; set; }
        public virtual ICollection<ItensReq> ItensReqs { get; set; }
    }
}
