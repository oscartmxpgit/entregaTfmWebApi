using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCartaBEPrj.Models;
using eCartaBE.Controllers;
using eCartaBE.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eCartaBEPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly BDeCarta _context;        

        public EmpleadosController(BDeCarta context)
        {
            _context = context;
        }

        // GET: api/Empleados/Dni/Y8832807Q
        [HttpGet("Dni/{dni}")]
        public async Task<ActionResult<Empleado>> GetEmpleadoPorDni(string dni)
        {
            return await _context.Empleados
                .Where(n => n.Dni == dni)
                .FirstOrDefaultAsync();
        }

        // GET: api/Empleados/negocio/idNegocio
        [HttpGet("negocio/{idNegocio}")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetNegociosPorEncargado(int idNegocio)
        {
            return await _context.Empleados
                .Where(e => e.IdNegocio == idNegocio)
                .ToListAsync();
        }

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // PUT: api/Empleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/Empleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            if (_context.Empleados.Count(e => (e.Dni == empleado.Dni)) == 0)
            {
                empleado.Pass = BCrypt.Net.BCrypt.HashPassword(empleado.Pass);
                _context.Empleados.Add(empleado);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEmpleado", new { id = empleado.IdEmpleado}, empleado);
            }
            else
            {
                return StatusCode(500, new { error = "Ya existe un encargado con ese Dni" });
            }

        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
    }

}
