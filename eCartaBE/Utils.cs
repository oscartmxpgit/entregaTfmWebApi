using eCartaBEPrj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eCartaBEPrj
{
    public class Fechas
    {
        [Required]
        [JsonPropertyName("fechainicial")]
        public DateTime fechaInicial { get; set; }

        [Required]
        [JsonPropertyName("fechafinal")]
        public DateTime fechaFinal { get; set; }
    }

    public class TotalCaja
    {
        public double incremento { get; set; }
        public double decremento { get; set; }
        public double tasaCrecimiento { get; set; }
    }
    public static class Utils
    {
        public static double OperacionCaja(BDeCarta _context, int idNegocio, string tipo, DateTime fechaHasta)
        {            
            double valor = _context.OperacionesCajas
                .Where(e => e.IdNegocio == idNegocio)
                .Where(e => e.Tipo == tipo)
                .Where(e => e.FechaHora <= fechaHasta)
                .Where(e=>e.Estado== "Validado")
                .Sum(e => e.Cantidad * e.Importe)
                .GetValueOrDefault();

            return valor;
        }

        public static bool GetIfOpCajasPorNegocio(BDeCarta _context, int idNegocio, string tipo)
        {
           var elements= _context.OperacionesCajas
                .Where(e => e.IdNegocio == idNegocio)
                .Where(e => e.Tipo == tipo)
                .OrderBy(e=>e.FechaHora)
                .ToList();
            if (elements.Count > 0) return true; else return false;
        }
        public static DateTime GetPrimeraOpCajasPorNegocio(BDeCarta _context, int idNegocio, string tipo)
        {
            return (DateTime)_context.OperacionesCajas
                .Where(e => e.IdNegocio == idNegocio)
                .Where(e => e.Tipo == tipo)
                .OrderBy(e=>e.FechaHora)
                .FirstOrDefault().FechaHora;
        }
        public static DateTime GetUltimaOpCajasPorNegocio(BDeCarta _context, int idNegocio, string tipo)
        {
            return (DateTime)_context.OperacionesCajas
                .Where(e => e.IdNegocio == idNegocio)
                .Where(e => e.Tipo == tipo)
                .OrderBy(e=>e.FechaHora)
                .LastOrDefault().FechaHora;
        }
        public static double CalculateTasaCrecimiento(double valorFinal, double valorInicial)
        {
            //Calcular una tasa de crecimiento
            //tasa = ((valor final-valor inicial)/valor inicial)*100            

            double tasa = 0;
            if (valorInicial!=0)
                tasa = ((valorFinal - valorInicial) / valorInicial) * 100;
            else
                tasa = ((valorFinal - valorInicial) / 0.1) * 100;

            return tasa;
        }
    }
}
