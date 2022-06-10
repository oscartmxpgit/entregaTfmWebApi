using System;
using System.Collections.Generic;

#nullable disable

namespace eCartaBEPrj.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            EvaluacionEmpleados = new HashSet<EvaluacionEmpleado>();
        }

        public int IdEmpleado { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Pass { get; set; }
        public int IdNegocio { get; set; }
        public string Email { get; set; }

        public virtual Negocio IdNegocioNavigation { get; set; }
        public virtual ICollection<EvaluacionEmpleado> EvaluacionEmpleados { get; set; }
    }
}
