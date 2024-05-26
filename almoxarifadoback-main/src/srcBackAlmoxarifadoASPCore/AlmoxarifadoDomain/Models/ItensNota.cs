using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class ItensNota
    {
        public int ItemNum { get; set; }
        public int IdPro { get; set; }
        public int IdNota { get; set; }
        public int IdSec { get; set; }
        public decimal? QtdPro { get; set; }
        public decimal? PreUnit { get; set; }
        public decimal? TotalItem { get; set; }
        public decimal? EstLin { get; set; }

        public virtual NotaFiscal IdNotaNavigation { get; set; } = null!;
        public virtual Produto IdProNavigation { get; set; } = null!;
    }
}
