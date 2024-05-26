using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO {
    public class ItensNotaPostDTO 
    {
        public int ItemNum { get; set; }
        public int IdPro { get; set; }
        public int IdNota { get; set; }
        public int IdSec { get; set; }
        public decimal? QtdPro { get; set; }
        public decimal? PreUnit { get; set; }
        public decimal? TotalItem { get; set; }
        public decimal? EstLin { get; set; }
    }

    public class ItensNotaGetDTO {
        public int ItemNum { get; set; }
        public int IdPro { get; set; }
        public int IdNota { get; set; }
        public int IdSec { get; set; }
        public decimal? QtdPro { get; set; }
        public decimal? PreUnit { get; set; }
        public decimal? TotalItem { get; set; }
        public decimal? EstLin { get; set; }
    }
}
