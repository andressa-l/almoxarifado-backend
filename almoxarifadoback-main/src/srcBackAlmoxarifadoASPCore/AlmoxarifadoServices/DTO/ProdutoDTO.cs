using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO {
   
        public class ProdutoPostDTO {
            public string Nome { get; set; }
            public int Quantidade { get; set; }
        }

        public class ProdutoGetDTO {
            public int Id { get; set; }
            public string Nome { get; set; }
            public int Quantidade { get; set; }
        }
    

}
