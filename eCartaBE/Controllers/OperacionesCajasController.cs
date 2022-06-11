using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCartaBEPrj.Models;
using static eCartaBEPrj.Utils;

namespace eCartaBEPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesCajasController : ControllerBase
    {
        private readonly BDeCarta _context;

        public OperacionesCajasController(BDeCarta context)
        {
            _context = context;
        }
      
        // GET: api/OperacionesCajas/totalcaja/negocio/idNegocio
        [HttpGet("totalcaja/negocio/{idNegocio}")]
        public TotalCaja GetTotalCajaPorNegocio(int idNegocio)
        {
            TotalCaja totalCaja = new TotalCaja();

            if (!GetIfOpCajasPorNegocio(_context,idNegocio,"Incremento"))
            {
                totalCaja.incremento = 0;
                totalCaja.decremento = 0;
                totalCaja.tasaCrecimiento = 0;

                return totalCaja;
            }

            DateTime fechaInicial = Utils.GetPrimeraOpCajasPorNegocio(_context, idNegocio, "Incremento");
            DateTime fechaFinal = Utils.GetUltimaOpCajasPorNegocio(_context, idNegocio, "Incremento");
            
            double incrementoFinal = Utils.OperacionCaja(_context, idNegocio, "Incremento", fechaFinal);
            double incrementoInicial = Utils.OperacionCaja(_context, idNegocio, "Incremento", fechaInicial);

            DateTime fechaDecrementoFinal = Utils.GetUltimaOpCajasPorNegocio(_context, idNegocio, "Decremento");
            double decrementoFinal = Utils.OperacionCaja(_context, idNegocio, "Decremento", fechaDecrementoFinal);
            
            double valorFinal = incrementoFinal;

            double valorInicial = incrementoInicial;

            double tasa = CalculateTasaCrecimiento(valorFinal, valorInicial);

            totalCaja.incremento = incrementoFinal;
            totalCaja.decremento = decrementoFinal;
            totalCaja.tasaCrecimiento = tasa;

            return totalCaja;
        }


        // GET: api/Cajas/validadas/negocio/idNegocio
        [HttpGet("validadas/negocio/{idNegocio}")]
        public async Task<ActionResult<IEnumerable<OperacionesCaja>>> GetCajasValidadasPorNegocio(int idNegocio)
        {
            return await _context.OperacionesCajas
                .Where(e => e.IdNegocio == idNegocio)
                .Where(e => e.Tipo == "Incremento")
                .Where(e => e.Estado == "Validado")
                .ToListAsync();
        }

        // GET: api/Cajas/negocio/idNegocio
        [HttpGet("negocio/{idNegocio}")]
        public async Task<ActionResult<IEnumerable<OperacionesCaja>>> GetCajasPorNegocio(int idNegocio)
        {
            return await _context.OperacionesCajas
                .Where(e => e.IdNegocio == idNegocio)
                .ToListAsync();
        }

        // GET: api/Cajas/incremento/negocio/idNegocio
        [HttpGet("incremento/negocio/{idNegocio}")]
        public async Task<ActionResult<IEnumerable<OperacionesCaja>>> GetIncrementosCajaPorNegocio(int idNegocio)
        {
            return await _context.OperacionesCajas
                .Where(e => e.IdNegocio == idNegocio)
                .Where(e => e.Tipo == "Incremento")
                .Where(e => e.Estado == "Validado")
                .Where(e => e.Producto != "-")
                .Where(e => e.Producto != null)
                .ToListAsync();
        }

        // GET: api/OperacionesCajas/operacionesDia
        [HttpGet("operacionesDia")]
        public async Task<ActionResult<IEnumerable<OperacionesCaja>>> GetOperacionesCajasDia()
        {
            return await _context.OperacionesCajas
                .Where(e=>e.FechaHora.Value.Date==DateTime.Today)
                .Where(e=>e.Producto!="-")
                .Where(e=>e.Operacion== "Plato pagado")
                .ToListAsync();
        }

        // GET: api/OperacionesCajas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperacionesCaja>>> GetOperacionesCajas()
        {
            return await _context.OperacionesCajas.ToListAsync();
        }

        // GET: api/OperacionesCajas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperacionesCaja>> GetOperacionCaja(int id)
        {
            var operacionesCaja = await _context.OperacionesCajas.FindAsync(id);

            if (operacionesCaja == null)
            {
                return NotFound();
            }

            return operacionesCaja;
        }

        // PUT: api/OperacionesCajas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperacionCaja(int id, OperacionesCaja operacionesCaja)
        {
            if (id != operacionesCaja.IdOperacionesCaja)
            {
                return BadRequest();
            }

            _context.Entry(operacionesCaja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperacionesCajaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OperacionesCajas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OperacionesCaja>> PostOperacionCaja(OperacionesCaja operacionesCaja)
        {
            _context.OperacionesCajas.Add(operacionesCaja);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostOperacionCaja), new { id = operacionesCaja.IdOperacionesCaja }, operacionesCaja);
        }

        // DELETE: api/OperacionesCajas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperacionCaja(int id)
        {
            var operacionesCaja = await _context.OperacionesCajas.FindAsync(id);
            if (operacionesCaja == null)
            {
                return NotFound();
            }

            _context.OperacionesCajas.Remove(operacionesCaja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperacionesCajaExists(int id)
        {
            return _context.OperacionesCajas.Any(e => e.IdOperacionesCaja == id);
        }
    }

    
}
