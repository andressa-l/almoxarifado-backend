using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO {
    public class NotaFiscalPostDTO 
    {
        public int? IdFor { get; set; }
        public int IdSec { get; set; }
        public string NumNota { get; set; } = null!;
        public int Ano { get; set; }
        public int? Mes { get; set; }
        public int IdTipoNota { get; set; }
        public string? ObservacaoNota { get; set; }
    }

    public class NotaFiscalGetDTO 
    {
        public int IdNota { get; set; }
        public int? IdFor { get; set; }
        public int IdSec { get; set; }
        public string NumNota { get; set; } = null!;
        public decimal ValorNota { get; set; }
        public int QtdItem { get; set; }
        public int? Icms { get; set; }
        public int? Iss { get; set; }
        public int Ano { get; set; }
        public int? Mes { get; set; }
        public DateTime? DataNota { get; set; }
        public int IdTipoNota { get; set; }
        public string? ObservacaoNota { get; set; }
        public int? EmpenhoNum { get; set; }
    }

    public class NotaFiscalPutDTO {
        public int? IdFor { get; set; }
        public int IdSec { get; set; }
        public string NumNota { get; set; } = null!;
        public decimal ValorNota { get; set; }
        public int QtdItem { get; set; }
        public int? Icms { get; set; }
        public int? Iss { get; set; }
        public int Ano { get; set; }
        public int? Mes { get; set; }
        public DateTime? DataNota { get; set; }
        public int IdTipoNota { get; set; }
        public string? ObservacaoNota { get; set; }
        public int? EmpenhoNum { get; set; }
    }
}
