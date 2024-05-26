using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class Requisicao
    {
        public Requisicao()
        {
            ItensReqs = new HashSet<ItensReq>();
        }

        public int IdReq { get; set; }
        public int IdCli { get; set; }
        public decimal? TotalReq { get; set; }
        public int? QtdIten { get; set; }
        public DateTime DataReq { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public int IdSec { get; set; }
        public int? IdSet { get; set; }
        public string? Observacao { get; set; }

        public virtual Cliente IdCliNavigation { get; set; } = null!;
        public virtual Setor? IdSetNavigation { get; set; }
        public virtual ICollection<ItensReq> ItensReqs { get; set; }
    }
}
