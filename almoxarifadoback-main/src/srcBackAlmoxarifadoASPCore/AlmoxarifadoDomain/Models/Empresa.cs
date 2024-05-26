using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class Empresa
    {
        public int IdEmpresa { get; set; }
        public string? NomeEmpresa { get; set; }
        public string? EnderecoEmpresa { get; set; }
        public string? BairroEmpresa { get; set; }
        public string? CidadeEmpresa { get; set; }
        public string? UfEmpresa { get; set; }
        public string? CepEmpresa { get; set; }
        public string? CnpjEmpresa { get; set; }
        public string? FoneEmresa { get; set; }
        public byte[]? LogoEmpresa { get; set; }
    }
}
