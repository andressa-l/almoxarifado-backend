using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO {
    public class ItensReqGetDTO {
        public int NumItem { get; set; }
        public int IdPro { get; set; }
        public int IdReq { get; set; }
        public int IdSec { get; set; }
        public decimal QtdPro { get; set; }
        public decimal? PreUnit { get; set; }
        public decimal? TotalItem { get; set; }
        public decimal? TotalReal { get; set; }
    }

    public class ItensReqPostDTO {
        public int IdPro { get; set; }
        public int IdReq { get; set; }
        public int IdSec { get; set; }
        public decimal QtdPro { get; set; }
        public decimal? PreUnit { get; set; }
        public decimal? TotalItem { get; set; }
        public decimal? TotalReal { get; set; }
    }

}
