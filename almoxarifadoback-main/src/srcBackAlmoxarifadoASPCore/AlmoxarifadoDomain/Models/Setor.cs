using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class Setor
    {
        public Setor()
        {
            Requisicaos = new HashSet<Requisicao>();
        }

        public int IdSet { get; set; }
        public int? IdSec { get; set; }
        public string? NomeSet { get; set; }

        public virtual Secretarium? IdSecNavigation { get; set; }
        public virtual ICollection<Requisicao> Requisicaos { get; set; }
    }
}
