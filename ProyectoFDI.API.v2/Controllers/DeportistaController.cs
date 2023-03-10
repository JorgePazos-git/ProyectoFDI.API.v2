using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using ProyectoFDI.API.v2.Models;

namespace ProyectoFDI.API.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeportistaController : ControllerBase
    {
        private readonly ProyectoFdiV2Context _context;

        public DeportistaController(ProyectoFdiV2Context context)
        {
            _context = context;
        }

        // GET: api/Deportista
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deportistum>>> GetDeportista(string? searchFor)
        {
            var datos = _context.Deportista;

            if (string.IsNullOrWhiteSpace(searchFor))
            {
                return await datos.ToListAsync();
            }
            else
            {
                return await datos.Where(p =>
                    p.ApellidosDep.ToLower().Contains(searchFor.ToLower()) ||
                    p.CedulaDep.ToLower().Contains(searchFor.ToLower()) ||
                    p.IdCatNavigation.NombreCat.ToLower().Contains(searchFor.ToLower()) ||
                    p.IdClubNavigation.NombreClub.ToLower().Contains(searchFor.ToLower()) ||
                    p.IdEntNavigation.NombresEnt.ToLower().Contains(searchFor.ToLower()) ||
                    p.IdGenNavigation.NombreGen.ToLower().Contains(searchFor.ToLower()) ||
                    p.IdUsuNavigation.NombreUsu.ToLower().Contains(searchFor.ToLower()) ||
                    p.NombresDep.ToLower().Contains(searchFor.ToLower()) ||
                    p.IdProNavigation.NombrePro.ToLower().Contains(searchFor.ToLower())

                ).ToListAsync();
            }

            //return await _context.Deportista
            //    .ToListAsync();
        }

        // GET: api/Deportista/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deportistum>> GetDeportistum(int id)
        {
            var deportistum = await _context
                .Deportista
                .Where(x => x.IdDep == id)
                .ToListAsync();

            if (deportistum == null)
            {
                return NotFound();
            }

            return deportistum[0];
        }

        // PUT: api/Deportista/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeportistum(int id, Deportistum deportistum)
        {
            if (id != deportistum.IdDep)
            {
                return BadRequest();
            }

            _context.Entry(deportistum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeportistumExists(id))
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

        // POST: api/Deportista
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deportistum>> PostDeportistum(Deportistum deportistum)
        {
            _context.Deportista.Add(deportistum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeportistum", new { id = deportistum.IdDep }, deportistum);
        }

        // DELETE: api/Deportista/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeportistum(int id)
        {
            var deportistum = await _context.Deportista
                .Where(x => x.IdDep == id)
                .ToListAsync();
            if (deportistum == null)
            {
                return NotFound();
            }

            _context.Deportista.Remove(deportistum[0]);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeportistumExists(int id)
        {
            return _context.Deportista.Any(e => e.IdDep == id);
        }
    }
}
