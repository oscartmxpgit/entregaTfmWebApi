using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCartaBEPrj.Models
{
    [ModelMetadataType(typeof(Empleado_Annotations))]
    public partial class Empleado
    {

    }
    public partial class Empleado_Annotations
    {
        [Display(
            Description = "Nombre del empleado",
            Name = "Nombre: ",
            ShortName = "Nombre: ",
            Prompt = "Nombre del cliente")]
        [Required(ErrorMessage = "Debe escribir un nombre para el cliente")]
        public string Nombre { get; set; }

        [Display(
            Description = "Teléfono del empleado",
            Name = "Teléfono: ",
            ShortName = "Teléfono: ",
            Prompt = "Teléfono del cliente")]

        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{1,6}$",
            ErrorMessage = "Por favor introduce un número de teléfono válido")]
        public string Telefono { get; set; }

    }

}
