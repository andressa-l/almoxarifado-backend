using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Requisicaos = new HashSet<Requisicao>();
        }

        public int IdCli { get; set; }
        public int? IdSec { get; set; }
        public string? NomeCli { get; set; }
        public string? Cargo { get; set; }
        public int? Portaria { get; set; }

        public virtual Secretarium? IdSecNavigation { get; set; }
        public virtual ICollection<Requisicao> Requisicaos { get; set; }
    }
}
