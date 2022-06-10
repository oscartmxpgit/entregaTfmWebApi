using System;
using System.Collections.Generic;

#nullable disable

namespace eCartaBEPrj.Models
{
    public partial class OperacionesCaja
    {
        public int IdOperacionesCaja { get; set; }
        public string Operacion { get; set; }
        public double? Importe { get; set; }
        public DateTime? FechaHora { get; set; }
        public string Producto { get; set; }
        public int? IdNegocio { get; set; }
        public short? Cantidad { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }

        public virtual Negocio IdNegocioNavigation { get; set; }
    }
}
