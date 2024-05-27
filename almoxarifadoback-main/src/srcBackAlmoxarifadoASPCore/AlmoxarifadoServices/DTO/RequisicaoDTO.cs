using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO {
    public class RequisicaoGetDTO {
        public int IdReq { get; set; }
        public int IdCli { get; set; }
        public decimal? TotalReq { get; set; }
        public int? QtdIten { get; set; }
        public DateTime DataReq { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public int IdSec { get; set; }
        public int? IdSet { get; set; }
        public string? Observacao { get; set; }

    }

    public class RequisicaoPostDTO {
        public int IdSec { get; set; }
        public int? IdSet { get; set; }
        public int IdCli { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
    
        public string? Observacao { get; set; }
    }

    public class RequisicaoUpdateDTO {
        public int IdReq { get; set; }
        public int IdCli { get; set; }
        public decimal? TotalReq { get; set; }
        public int? QtdIten { get; set; }
        public DateTime DataReq { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public int IdSec { get; set; }
        public int? IdSet { get; set; }
        public string? Observacao { get; set; }
    }

    public class RequisicaoPutDTO {
        public int IdCli { get; set; }
        public decimal? TotalReq { get; set; }
        public int? QtdIten { get; set; }
        public DateTime DataReq { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public int IdSec { get; set; }
        public int? IdSet { get; set; }
        public string? Observacao { get; set; }
    }
}
