using System;
using System.Collections.Generic;

namespace AlmoxarifadoDomain.Models
{
    public partial class Sistema
    {
        public string Sisid { get; set; } = null!;
        public string Sisdescricao { get; set; } = null!;
        public string Sischave { get; set; } = null!;
        public string? Da { get; set; }
        public string? Du { get; set; }
    }
}
