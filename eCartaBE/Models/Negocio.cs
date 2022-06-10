using System;
using System.Collections.Generic;

#nullable disable

namespace eCartaBEPrj.Models
{
    public partial class Negocio
    {
        public Negocio()
        {
            Empleados = new HashSet<Empleado>();
            EvaluacionEmpleados = new HashSet<EvaluacionEmpleado>();
            Insumos = new HashSet<Insumo>();
            Mesas = new HashSet<Mesa>();
            OperacionesCajas = new HashSet<OperacionesCaja>();
            Platos = new HashSet<Plato>();
        }

        public int IdNegocio { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int IdEncargado { get; set; }
        public string Tipo { get; set; }

        public virtual Encargado IdEncargadoNavigation { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<EvaluacionEmpleado> EvaluacionEmpleados { get; set; }
        public virtual ICollection<Insumo> Insumos { get; set; }
        public virtual ICollection<Mesa> Mesas { get; set; }
        public virtual ICollection<OperacionesCaja> OperacionesCajas { get; set; }
        public virtual ICollection<Plato> Platos { get; set; }
    }
}
