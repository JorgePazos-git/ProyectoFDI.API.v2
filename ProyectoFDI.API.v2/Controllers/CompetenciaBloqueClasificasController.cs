using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFDI.API.v2.ModelsV2;

namespace ProyectoFDI.API.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenciaBloqueClasificasController : ControllerBase
    {
        private readonly ProyectoFdiV2Context _context;

        public CompetenciaBloqueClasificasController(ProyectoFdiV2Context context)
        {
            _context = context;
        }

        // GET: api/CompetenciaBloqueClasificas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetenciaBloqueClasifica>>> GetCompetenciaBloqueClasificas()
        {
          if (_context.CompetenciaBloqueClasificas == null)
          {
              return NotFound();
          }
            return await _context.CompetenciaBloqueClasificas.ToListAsync();
        }

        // GET: api/CompetenciaBloqueClasificas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompetenciaBloqueClasifica>> GetCompetenciaBloqueClasifica(int id)
        {
          if (_context.CompetenciaBloqueClasificas == null)
          {
              return NotFound();
          }
            var competenciaBloqueClasifica = await _context.CompetenciaBloqueClasificas.FindAsync(id);

            if (competenciaBloqueClasifica == null)
            {
                return NotFound();
            }

            return competenciaBloqueClasifica;
        }

        // PUT: api/CompetenciaBloqueClasificas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetenciaBloqueClasifica(int id, CompetenciaBloqueClasifica competenciaBloqueClasifica)
        {
            if (id != competenciaBloqueClasifica.IdCompeBloqueCla)
            {
                return BadRequest();
            }

            _context.Entry(competenciaBloqueClasifica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetenciaBloqueClasificaExists(id))
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

        // POST: api/CompetenciaBloqueClasificas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompetenciaBloqueClasifica>> PostCompetenciaBloqueClasifica(CompetenciaBloqueClasifica competenciaBloqueClasifica)
        {
          if (_context.CompetenciaBloqueClasificas == null)
          {
              return Problem("Entity set 'ProyectoFdiV2Context.CompetenciaBloqueClasificas'  is null.");
          }
            _context.CompetenciaBloqueClasificas.Add(competenciaBloqueClasifica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompetenciaBloqueClasifica", new { id = competenciaBloqueClasifica.IdCompeBloqueCla }, competenciaBloqueClasifica);
        }

        // DELETE: api/CompetenciaBloqueClasificas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetenciaBloqueClasifica(int id)
        {
            if (_context.CompetenciaBloqueClasificas == null)
            {
                return NotFound();
            }
            var competenciaBloqueClasifica = await _context.CompetenciaBloqueClasificas.FindAsync(id);
            if (competenciaBloqueClasifica == null)
            {
                return NotFound();
            }

            _context.CompetenciaBloqueClasificas.Remove(competenciaBloqueClasifica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetenciaBloqueClasificaExists(int id)
        {
            return (_context.CompetenciaBloqueClasificas?.Any(e => e.IdCompeBloqueCla == id)).GetValueOrDefault();
        }
    }
}
