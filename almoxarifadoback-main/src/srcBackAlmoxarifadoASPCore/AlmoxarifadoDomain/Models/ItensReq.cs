using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class ItensReq
    {
        public int NumItem { get; set; }
        public int IdPro { get; set; }
        public int IdReq { get; set; }
        public int IdSec { get; set; }
        public decimal QtdPro { get; set; }
        public decimal? PreUnit { get; set; }
        public decimal? TotalItem { get; set; }
        public decimal? TotalReal { get; set; }

        public virtual Produto IdProNavigation { get; set; } = null!;
        public virtual Requisicao IdReqNavigation { get; set; } = null!;
    }
}
