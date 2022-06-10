using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCartaBEPrj.Models;

namespace eCartaBEPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluacionEmpleadosController : ControllerBase
    {
        private readonly BDeCarta _context;

        public EvaluacionEmpleadosController(BDeCarta context)
        {
            _context = context;
        }

        // GET: api/Empleados/IdEmpleado
        [HttpGet("empleados/{IdEmpleado}")]
        public async Task<ActionResult<IEnumerable<EvaluacionEmpleado>>> GetEvalEmpPorEmp(int IdEmpleado)
        {
            return await _context.EvaluacionEmpleados
                .Where(e => e.IdEmpleado== IdEmpleado)
                .ToListAsync();
        }

        // GET: api/Empleados/negocio/idNegocio
        [HttpGet("negocio/{idNegocio}")]
        public async Task<ActionResult<IEnumerable<EvaluacionEmpleado>>> GetEvalEmpPorNeg(int idNegocio)
        {
            return await _context.EvaluacionEmpleados
                .Where(e => e.IdNegocio == idNegocio)
                .ToListAsync();
        }

        // GET: api/EvaluacionEmpleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvaluacionEmpleado>>> GetEvaluacionEmpleados()
        {
            return await _context.EvaluacionEmpleados.ToListAsync();
        }

        // GET: api/EvaluacionEmpleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluacionEmpleado>> GetEvaluacionEmpleado(int id)
        {
            var evaluacionEmpleado = await _context.EvaluacionEmpleados.FindAsync(id);

            if (evaluacionEmpleado == null)
            {
                return NotFound();
            }

            return evaluacionEmpleado;
        }

        // PUT: api/EvaluacionEmpleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluacionEmpleado(int id, EvaluacionEmpleado evaluacionEmpleado)
        {
            if (id != evaluacionEmpleado.IdEvaluacionEmpleado)
            {
                return BadRequest();
            }

            _context.Entry(evaluacionEmpleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluacionEmpleadoExists(id))
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

        // POST: api/EvaluacionEmpleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EvaluacionEmpleado>> PostEvaluacionEmpleado(EvaluacionEmpleado evaluacionEmpleado)
        {
            _context.EvaluacionEmpleados.Add(evaluacionEmpleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvaluacionEmpleado", new { id = evaluacionEmpleado.IdEvaluacionEmpleado }, evaluacionEmpleado);
        }

        // DELETE: api/EvaluacionEmpleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluacionEmpleado(int id)
        {
            var evaluacionEmpleado = await _context.EvaluacionEmpleados.FindAsync(id);
            if (evaluacionEmpleado == null)
            {
                return NotFound();
            }

            _context.EvaluacionEmpleados.Remove(evaluacionEmpleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvaluacionEmpleadoExists(int id)
        {
            return _context.EvaluacionEmpleados.Any(e => e.IdEvaluacionEmpleado == id);
        }
    }
}
