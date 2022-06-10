using System;
using System.Collections.Generic;

#nullable disable

namespace eCartaBEPrj.Models
{
    public partial class EvaluacionEmpleado
    {
        public int IdEvaluacionEmpleado { get; set; }
        public int IdEmpleado { get; set; }
        public string Criterio { get; set; }
        public short Evaluacion { get; set; }
        public int IdNegocio { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Negocio IdNegocioNavigation { get; set; }
    }
}
