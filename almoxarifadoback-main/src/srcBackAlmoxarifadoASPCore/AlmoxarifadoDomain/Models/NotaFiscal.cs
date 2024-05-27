using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class NotaFiscal
    {
        public NotaFiscal()
        {
            ItensNota = new HashSet<ItensNota>();
        }

        public int IdNota { get; set; }
        public int? IdFor { get; set; }
        public int IdSec { get; set; }
        public string NumNota { get; set; } = null!;
        public decimal ValorNota { get; set; }
        public int QtdItem { get; set; }
        public int? Icms { get; set; }
        public int? Iss { get; set; }
        public int Ano { get; set; }
        public int? Mes { get; set; }
        public DateTime? DataNota { get; set; }
        public int IdTipoNota { get; set; }
        public string? ObservacaoNota { get; set; }
        public int? EmpenhoNum { get; set; }

        public virtual Fornecedor? IdForNavigation { get; set; }
        public virtual Secretarium IdSecNavigation { get; set; } = null!;
        public virtual TipoNotum IdTipoNotaNavigation { get; set; } = null!;
        public virtual ICollection<ItensNota> ItensNota { get; set; }
    }
}
