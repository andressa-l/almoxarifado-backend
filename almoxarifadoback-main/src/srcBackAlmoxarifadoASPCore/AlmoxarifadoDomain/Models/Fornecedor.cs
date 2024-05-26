using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            NotaFiscals = new HashSet<NotaFiscal>();
        }

        public int IdFor { get; set; }
        public string Fantasia { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public string? Responsavel { get; set; }
        public string? InsMunicipal { get; set; }
        public string? InsEstadual { get; set; }
        public string? Endereco { get; set; }
        public string? Bairro { get; set; }
        public string? Uf { get; set; }
        public string? Telefone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }

        public virtual ICollection<NotaFiscal> NotaFiscals { get; set; }
    }
}
