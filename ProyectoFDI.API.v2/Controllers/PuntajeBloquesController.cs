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
    public class PuntajeBloquesController : ControllerBase
    {
        private readonly ProyectoFdiV2Context _context;

        public PuntajeBloquesController(ProyectoFdiV2Context context)
        {
            _context = context;
        }

        // GET: api/PuntajeBloques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuntajeBloque>>> GetPuntajeBloques()
        {
          if (_context.PuntajeBloques == null)
          {
              return NotFound();
          }
            return await _context.PuntajeBloques.ToListAsync();
        }

        // GET: api/PuntajeBloques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PuntajeBloque>> GetPuntajeBloque(int id)
        {
          if (_context.PuntajeBloques == null)
          {
              return NotFound();
          }
            var puntajeBloque = await _context.PuntajeBloques.FindAsync(id);

            if (puntajeBloque == null)
            {
                return NotFound();
            }

            return puntajeBloque;
        }

        [HttpGet("{idcom}/{iddep}/{numerobloque}")]
        public async Task<ActionResult<PuntajeBloque>> GetPuntajeBloque(int idcom, int iddep, int numerobloque)
        {
            var puntajeBloque = await _context.PuntajeBloques
                .Where(p => p.IdCom == idcom && p.IdDep == iddep && p.NumeroBloque == numerobloque)
                .SingleOrDefaultAsync();

            if (puntajeBloque == null)
            {
                return NotFound();
            }

            return puntajeBloque;
        }


        // PUT: api/PuntajeBloques/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuntajeBloque(int id, PuntajeBloque puntajeBloque)
        {
            if (id != puntajeBloque.IdBloPts)
            {
                return BadRequest();
            }

            _context.Entry(puntajeBloque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuntajeBloqueExists(id))
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

        // POST: api/PuntajeBloques
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PuntajeBloque>> PostPuntajeBloque(PuntajeBloque puntajeBloque)
        {
          if (_context.PuntajeBloques == null)
          {
              return Problem("Entity set 'ProyectoFdiV2Context.PuntajeBloques'  is null.");
          }
            _context.PuntajeBloques.Add(puntajeBloque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPuntajeBloque", new { id = puntajeBloque.IdBloPts }, puntajeBloque);
        }

        // DELETE: api/PuntajeBloques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuntajeBloque(int id)
        {
            if (_context.PuntajeBloques == null)
            {
                return NotFound();
            }
            var puntajeBloque = await _context.PuntajeBloques.FindAsync(id);
            if (puntajeBloque == null)
            {
                return NotFound();
            }

            _context.PuntajeBloques.Remove(puntajeBloque);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuntajeBloqueExists(int id)
        {
            return (_context.PuntajeBloques?.Any(e => e.IdBloPts == id)).GetValueOrDefault();
        }
        // GET: api/PuntajeBloques/ByIdCom/5
        [HttpGet("Competencia/{id}")]
        public async Task<ActionResult<IEnumerable<PuntajeBloque>>> GetPuntajeBloqueByCom(int id)
        {
            var puntajeBloques = await _context.PuntajeBloques
                .Where(pb => pb.IdCom == id)
                .ToListAsync();

            if (puntajeBloques == null || !puntajeBloques.Any())
            {
                return NotFound();
            }

            return puntajeBloques;
        }

    }
}
