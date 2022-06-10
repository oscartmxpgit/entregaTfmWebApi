using System;
using System.Collections.Generic;

#nullable disable

namespace eCartaBEPrj.Models
{
    public partial class Encargado
    {
        public Encargado()
        {
            Negocios = new HashSet<Negocio>();
        }

        public int IdEncargado { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Pass { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Negocio> Negocios { get; set; }
    }
}
