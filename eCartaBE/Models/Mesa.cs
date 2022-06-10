using System;
using System.Collections.Generic;

#nullable disable

namespace eCartaBEPrj.Models
{
    public partial class Mesa
    {
        public int IdMesa { get; set; }
        public short Personas { get; set; }
        public string Comentario { get; set; }
        public int IdNegocio { get; set; }
        public short? NoMesa { get; set; }
        public string EstadoPedido { get; set; }

        public virtual Negocio IdNegocioNavigation { get; set; }
    }
}
