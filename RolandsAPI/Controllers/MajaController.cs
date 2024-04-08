using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RolandsAPI.Data;
using RolandsAPI.Models;

namespace RolandsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajaController : ControllerBase
    {
        private readonly ApiContext _context;

        public MajaController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Maja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MajaDTO>>> GetMajas()
        {
            return await _context.Majas
                .Select(x =>ItemToDTO(x))
                .ToListAsync();
        }

        // GET: api/Maja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MajaDTO>> GetMaja(int id)
        {
            var maja = await _context.Majas.FindAsync(id);

            if (maja == null)
            {
                return NotFound();
            }

            return ItemToDTO(maja);
        }

        // PUT: api/Maja/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaja(int id, MajaDTO majaDTO)
        {
            if (id != majaDTO.Id)
            {
                return BadRequest();
            }

            var maja = await _context.Majas.FindAsync(id);
            if (maja == null)
            {
                return NotFound();
            }

            maja.Id = majaDTO.Id;
            maja.Numurs = majaDTO.Numurs;
            maja.Iela = majaDTO.Iela;
            maja.Pilseta = majaDTO.Pilseta;
            maja.Valsts = majaDTO.Valsts;
            maja.PastaIndekss = majaDTO.PastaIndekss;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MajaExists(id))
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

        // POST: api/Maja
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MajaDTO>> PostMaja(MajaDTO majaDTO)
        {
            var maja = new Maja
            {
                Id = majaDTO.Id,
                Numurs = majaDTO.Numurs,
                Iela = majaDTO.Iela,
                Pilseta = majaDTO.Pilseta,
                Valsts = majaDTO.Valsts,
                PastaIndekss = majaDTO.PastaIndekss
            };

            _context.Majas.Add(maja);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMaja), new { id = maja.Id }, ItemToDTO(maja));
        }

        // DELETE: api/Maja/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaja(int id)
        {
            var maja = await _context.Majas.FindAsync(id);
            if (maja == null)
            {
                return NotFound();
            }

            _context.Majas.Remove(maja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MajaExists(int id)
        {
            return _context.Majas.Any(e => e.Id == id);
        }

        private static MajaDTO ItemToDTO(Maja maja) =>
       new MajaDTO
       {
           Id = maja.Id,
           Numurs = maja.Numurs,
           Iela = maja.Iela,
           Pilseta = maja.Pilseta,
           Valsts = maja.Valsts,
           PastaIndekss = maja.PastaIndekss


       };
    }
}
