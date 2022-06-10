using System;
using System.Collections.Generic;

#nullable disable

namespace eCartaBEPrj.Models
{
    public partial class Plato
    {
        public int IdPlato { get; set; }
        public string Nombre { get; set; }
        public double? Precio { get; set; }
        public short? Stock { get; set; }
        public int? IdNegocio { get; set; }
        public string Tipo { get; set; }

        public virtual Negocio IdNegocioNavigation { get; set; }
    }
}
