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
    public class DzivoklisController : ControllerBase
    {
        private readonly ApiContext _context;

        public DzivoklisController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Dzivoklis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DzivoklisDTO>>> GetDzivokli()
        {
            return await _context.Dzivokli
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        // GET: api/Dzivoklis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DzivoklisDTO>> GetDzivoklis(int id)
        {
            var dzivoklis = await _context.Dzivokli.FindAsync(id);

            if (dzivoklis == null)
            {
                return NotFound();
            }

            return ItemToDTO(dzivoklis);
        }

        // PUT: api/Dzivoklis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDzivoklis(int id, DzivoklisDTO dzivoklisDTO)
        {
            if (id != dzivoklisDTO.Id)
            {
                return BadRequest();
            }

            var dzivoklis = await _context.Dzivokli.FindAsync(id);
            if (dzivoklis == null)
            {
                return NotFound();
            }

            dzivoklis.Id = dzivoklisDTO.Id;
            dzivoklis.Numurs = dzivoklisDTO.Numurs;
            dzivoklis.Stavs = dzivoklisDTO.Stavs;
            dzivoklis.IstabuSkaits = dzivoklisDTO.IstabuSkaits;
            dzivoklis.IedzivotajuSkaits = dzivoklisDTO.IedzivotajuSkaits;
            dzivoklis.PilnaPlatiba = dzivoklisDTO.PilnaPlatiba;
            dzivoklis.DzivojamaPlatiba = dzivoklisDTO.DzivojamaPlatiba;
            dzivoklis.MajaId = dzivoklisDTO.MajaId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DzivoklisExists(id))
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

        // POST: api/Dzivoklis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DzivoklisDTO>> PostDzivoklis(DzivoklisDTO dzivoklisDTO)
        {
            var dzivoklis = new Dzivoklis
            {
                Id = dzivoklisDTO.Id,
                Numurs = dzivoklisDTO.Numurs,
                Stavs = dzivoklisDTO.Stavs,
                IstabuSkaits = dzivoklisDTO.IstabuSkaits,
                IedzivotajuSkaits = dzivoklisDTO.IedzivotajuSkaits,
                PilnaPlatiba = dzivoklisDTO.PilnaPlatiba,
                DzivojamaPlatiba = dzivoklisDTO.DzivojamaPlatiba,
                MajaId = dzivoklisDTO.MajaId
            };


            _context.Dzivokli.Add(dzivoklis);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDzivoklis), new { id = dzivoklis.Id }, ItemToDTO(dzivoklis));
        }

        // DELETE: api/Dzivoklis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDzivoklis(int id)
        {
            var dzivoklis = await _context.Dzivokli.FindAsync(id);
            if (dzivoklis == null)
            {
                return NotFound();
            }

            _context.Dzivokli.Remove(dzivoklis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DzivoklisExists(int id)
        {
            return _context.Dzivokli.Any(e => e.Id == id);
        }

        private static DzivoklisDTO ItemToDTO(Dzivoklis dzivoklis) =>
       new DzivoklisDTO
       {
           Id = dzivoklis.Id,
           Numurs = dzivoklis.Numurs,
           Stavs = dzivoklis.Stavs,
           IstabuSkaits = dzivoklis.IstabuSkaits,
           IedzivotajuSkaits = dzivoklis.IedzivotajuSkaits,
           PilnaPlatiba = dzivoklis.PilnaPlatiba,
           DzivojamaPlatiba = dzivoklis.DzivojamaPlatiba,
           MajaId = dzivoklis.MajaId
       };
    }
}
