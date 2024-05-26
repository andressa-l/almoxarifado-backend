using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class MesCompetencium
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int? Aberto { get; set; }

        public virtual Ano AnoNavigation { get; set; } = null!;
    }
}
