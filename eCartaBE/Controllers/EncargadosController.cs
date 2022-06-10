using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCartaBEPrj.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using eCartaBE.Services;

namespace eCartaBEPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncargadosController : ControllerBase
    {
        private readonly BDeCarta _context;
        private readonly IUserService _userService;

        public EncargadosController(BDeCarta context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }


        [HttpPost("ChangePassword")]
        public async Task<ActionResult> CambiarPasswdEmpleados([FromBody] ChangePassRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_userService.IsValidUserCredentials(request.UserName, request.OldPass, _context))
            {
                return Unauthorized();
            }

            Encargado encargado = await _context.Encargados
                .Where(n => n.Dni == request.UserName)
                .FirstOrDefaultAsync();

            encargado.Pass = BCrypt.Net.BCrypt.HashPassword(request.NewPass);

            _context.Entry(encargado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }

        // GET: api/encargados/Dni/Y8832807Q
        [HttpGet("Dni/{dni}")]
        public async Task<ActionResult<Encargado>> GetEncargadoPorDni(string dni)
        {
            return await _context.Encargados
                .Where(n => n.Dni == dni)
                .FirstOrDefaultAsync();
        }

        // GET: api/Encargados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encargado>>> GetEncargados()
        {
            return await _context.Encargados.ToListAsync();
        }

        // GET: api/Encargados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Encargado>> GetEncargado(int id)
        {
            var encargado = await _context.Encargados.FindAsync(id);

            if (encargado == null)
            {
                return NotFound();
            }

            return encargado;
        }

        // PUT: api/Encargados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncargado(int id, Encargado encargado)
        {
            if (id != encargado.IdEncargado)
            {
                return BadRequest();
            }

            _context.Entry(encargado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncargadoExists(id))
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

        // POST: api/Encargados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Encargado>> PostEncargado(Encargado encargado)
        {
            if (_context.Encargados.Count(e => (e.Dni == encargado.Dni)) == 0)
            {
                encargado.Pass = BCrypt.Net.BCrypt.HashPassword(encargado.Pass);
                _context.Encargados.Add(encargado);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEncargado", new { id = encargado.IdEncargado }, encargado);
            }
            else
            {
                return StatusCode(500, new { error = "Ya existe un encargado con ese Dni" });
            }
            
        }

        // DELETE: api/Encargados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncargado(int id)
        {
            var encargado = await _context.Encargados.FindAsync(id);
            if (encargado == null)
            {
                return NotFound();
            }

            _context.Encargados.Remove(encargado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EncargadoExists(int id)
        {
            return _context.Encargados.Any(e => e.IdEncargado == id);
        }
    }

    public class ChangePassRequest
    {
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("oldPass")]
        public string OldPass { get; set; }

        [Required]
        [JsonPropertyName("newPass")]
        public string NewPass { get; set; }

    }
}
