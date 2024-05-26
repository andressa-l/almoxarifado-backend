using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class Movimentacao
    {
        public int IdMovi { get; set; }
        public int IdPro { get; set; }
        public int IdSec { get; set; }
        public int? IdReq { get; set; }
        public int? IdNota { get; set; }
        public decimal? PreUnit { get; set; }
        public decimal? QtdPro { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? EstAnt { get; set; }
        public bool TipoMov { get; set; }
        public int? MesMov { get; set; }
        public int AnoMov { get; set; }
        public DateTime DataMov { get; set; }
        public int? IdSet { get; set; }
    }
}
