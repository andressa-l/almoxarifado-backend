using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class Demonstrativo
    {
        public int? IdGru { get; set; }
        public string? NomeGru { get; set; }
        public int? IdSubGru { get; set; }
        public string? NomeSubGru { get; set; }
        public int? IdCla { get; set; }
        public string? NomeCla { get; set; }
        public int IdSec { get; set; }
        public string? NomeSec { get; set; }
        public string? UniMed { get; set; }
        public int IdPro { get; set; }
        public string? DescricaoPro { get; set; }
        public decimal? SaldoAnterior { get; set; }
        public decimal? SaldoAntCusto { get; set; }
        public decimal? EntradaQtd { get; set; }
        public decimal? EntradaVlUnit { get; set; }
        public decimal? SaidaQtd { get; set; }
        public decimal? SaidaCm { get; set; }
        public decimal? SaldoQtd { get; set; }
        public decimal? SaldoCm { get; set; }
    }
}
