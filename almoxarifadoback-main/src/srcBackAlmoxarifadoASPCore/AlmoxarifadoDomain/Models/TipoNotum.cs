using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class TipoNotum
    {
        public TipoNotum()
        {
            NotaFiscals = new HashSet<NotaFiscal>();
        }

        public int IdTipoNota { get; set; }
        public string? DescricaoTipoNota { get; set; }

        public virtual ICollection<NotaFiscal> NotaFiscals { get; set; }
    }
}
