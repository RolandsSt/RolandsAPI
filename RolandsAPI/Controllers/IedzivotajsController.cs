using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using RolandsAPI.Data;
using RolandsAPI.Models;

namespace RolandsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IedzivotajsController : ControllerBase
    {
        private readonly ApiContext _context;

        public IedzivotajsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Iedzivotajs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IedzivotajsDTO>>> GetIedzivotaji()
        {
            return await _context.Iedzivotaji
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        // GET: api/Iedzivotajs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IedzivotajsDTO>> GetIedzivotajs(int id)
        {
            var iedzivotajs = await _context.Iedzivotaji.FindAsync(id);

            if (iedzivotajs == null)
            {
                return NotFound();
            }

            return ItemToDTO(iedzivotajs);
        }

        // PUT: api/Iedzivotajs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIedzivotajs(int id, IedzivotajsDTO iedzivotajsDTO)
        {
            if (id != iedzivotajsDTO.Id)
            {
                return BadRequest();
            }

            var iedzivotajs = await _context.Iedzivotaji.FindAsync(id);
            if (iedzivotajs == null)
            {
                return NotFound();
            }

            iedzivotajs.Id = iedzivotajsDTO.Id;
            iedzivotajs.Vards = iedzivotajsDTO.Vards;
            iedzivotajs.Uzvards = iedzivotajsDTO.Uzvards;
            iedzivotajs.PersonasKods = iedzivotajsDTO.PersonasKods;
            iedzivotajs.DzimsanasDatums = iedzivotajsDTO.DzimsanasDatums;
            iedzivotajs.Telefons = iedzivotajsDTO.Telefons;
            iedzivotajs.Email = iedzivotajsDTO.Email;
            iedzivotajs.DzivoklisId = iedzivotajsDTO.DzivoklisId;
            iedzivotajs.IsOwner = iedzivotajsDTO.IsOwner;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IedzivotajsExists(id))
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

        // POST: api/Iedzivotajs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IedzivotajsDTO>> PostIedzivotajs(IedzivotajsDTO iedzivotajsDTO)
        {
            var iedzivotajs = new Iedzivotajs
            {
                Id = iedzivotajsDTO.Id,
                Vards = iedzivotajsDTO.Vards,
                Uzvards = iedzivotajsDTO.Uzvards,
                PersonasKods = iedzivotajsDTO.PersonasKods,
                DzimsanasDatums = iedzivotajsDTO.DzimsanasDatums,
                Telefons = iedzivotajsDTO.Telefons,
                Email = iedzivotajsDTO.Email,
                DzivoklisId = iedzivotajsDTO.DzivoklisId,
                IsOwner = iedzivotajsDTO.IsOwner
            };

            _context.Iedzivotaji.Add(iedzivotajs);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIedzivotajs), new { id = iedzivotajs.Id }, ItemToDTO(iedzivotajs));
        }

        // DELETE: api/Iedzivotajs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIedzivotajs(int id)
        {
            var iedzivotajs = await _context.Iedzivotaji.FindAsync(id);
            if (iedzivotajs == null)
            {
                return NotFound();
            }

            _context.Iedzivotaji.Remove(iedzivotajs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IedzivotajsExists(int id)
        {
            return _context.Iedzivotaji.Any(e => e.Id == id);
        }
        private static IedzivotajsDTO ItemToDTO(Iedzivotajs iedzivotajs) =>
       new IedzivotajsDTO
       {
           Id = iedzivotajs.Id,
           Vards = iedzivotajs.Vards,
           Uzvards = iedzivotajs.Uzvards,
           PersonasKods = iedzivotajs.PersonasKods,
           DzimsanasDatums = iedzivotajs.DzimsanasDatums,
           Telefons = iedzivotajs.Telefons,
           Email = iedzivotajs.Email,
           DzivoklisId = iedzivotajs.DzivoklisId,
           IsOwner = iedzivotajs.IsOwner
       };
    }
}
