using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFDI.API.v2.ModelsV4;

namespace ProyectoFDI.API.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenciaBloqueFinalsController : ControllerBase
    {
        private readonly ProyectoFdiV2Context _context;

        public CompetenciaBloqueFinalsController(ProyectoFdiV2Context context)
        {
            _context = context;
        }

        // GET: api/CompetenciaBloqueFinals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetenciaBloqueFinal>>> GetCompetenciaBloqueFinals()
        {
          if (_context.CompetenciaBloqueFinals == null)
          {
              return NotFound();
          }
            return await _context.CompetenciaBloqueFinals.ToListAsync();
        }

        // GET: api/CompetenciaBloqueFinals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompetenciaBloqueFinal>> GetCompetenciaBloqueFinal(int id)
        {
          if (_context.CompetenciaBloqueFinals == null)
          {
              return NotFound();
          }
            var competenciaBloqueFinal = await _context.CompetenciaBloqueFinals.FindAsync(id);

            if (competenciaBloqueFinal == null)
            {
                return NotFound();
            }

            return competenciaBloqueFinal;
        }

        // PUT: api/CompetenciaBloqueFinals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetenciaBloqueFinal(int id, CompetenciaBloqueFinal competenciaBloqueFinal)
        {
            if (id != competenciaBloqueFinal.IdCompeBloqueFinal)
            {
                return BadRequest();
            }

            _context.Entry(competenciaBloqueFinal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetenciaBloqueFinalExists(id))
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

        // POST: api/CompetenciaBloqueFinals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompetenciaBloqueFinal>> PostCompetenciaBloqueFinal(CompetenciaBloqueFinal competenciaBloqueFinal)
        {
          if (_context.CompetenciaBloqueFinals == null)
          {
              return Problem("Entity set 'ProyectoFdiV2Context.CompetenciaBloqueFinals'  is null.");
          }
            _context.CompetenciaBloqueFinals.Add(competenciaBloqueFinal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompetenciaBloqueFinal", new { id = competenciaBloqueFinal.IdCompeBloqueFinal }, competenciaBloqueFinal);
        }

        // DELETE: api/CompetenciaBloqueFinals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetenciaBloqueFinal(int id)
        {
            if (_context.CompetenciaBloqueFinals == null)
            {
                return NotFound();
            }
            var competenciaBloqueFinal = await _context.CompetenciaBloqueFinals.FindAsync(id);
            if (competenciaBloqueFinal == null)
            {
                return NotFound();
            }

            _context.CompetenciaBloqueFinals.Remove(competenciaBloqueFinal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetenciaBloqueFinalExists(int id)
        {
            return (_context.CompetenciaBloqueFinals?.Any(e => e.IdCompeBloqueFinal == id)).GetValueOrDefault();
        }
    }
}
