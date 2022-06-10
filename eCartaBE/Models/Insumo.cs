using System;
using System.Collections.Generic;

#nullable disable

namespace eCartaBEPrj.Models
{
    public partial class Insumo
    {
        public int IdInsumo { get; set; }
        public string Nombre { get; set; }
        public short Stock { get; set; }
        public int IdNegocio { get; set; }
        public double? Precio { get; set; }
        public string Estado { get; set; }

        public virtual Negocio IdNegocioNavigation { get; set; }
    }
}
