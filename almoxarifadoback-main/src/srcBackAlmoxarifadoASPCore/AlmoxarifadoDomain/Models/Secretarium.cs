using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class Secretarium
    {
        public Secretarium()
        {
            Clientes = new HashSet<Cliente>();
            NotaFiscals = new HashSet<NotaFiscal>();
            Setors = new HashSet<Setor>();
        }

        public int IdSec { get; set; }
        public string NomeSec { get; set; } = null!;
        public string? EndrecoSec { get; set; }
        public string? BairroSec { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<NotaFiscal> NotaFiscals { get; set; }
        public virtual ICollection<Setor> Setors { get; set; }
    }
}
