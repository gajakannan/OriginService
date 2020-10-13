using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

using OriginService.Models;

namespace OriginService.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class InputsController : ControllerBase
    {
        private readonly OriginContext _context;

        public InputsController(OriginContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inputs>>> GetInputs(bool? inStock, int? skip, int? take)
        {
            var inputs = _context.Inputs.AsQueryable();

            // if (inStock != null) // Adds the condition to check availability 
            // {
            //     inputs = _context.Inputs.Where(i => i.Availablequantity > 0);
            // }

            if (skip != null)
            {
                inputs = inputs.Skip((int)skip);
            }

            if (take != null)
            {
                inputs = inputs.Take((int)take);
            }

            return await inputs.ToListAsync();
        }

        // GET: api/Inputs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inputs>> GetInputs(int id)
        {
            var inputs = await _context.Inputs.FindAsync(id);

            if (inputs == null)
            {
                return NotFound();
            }

            return inputs;
        }

        // PUT: api/Inputs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInputs(int id, Inputs inputs)
        {
            if (id != inputs.Inputid)
            {
                return BadRequest();
            }

            _context.Entry(inputs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InputsExists(id))
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

        // POST: api/Inputs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Inputs>> PostInputs(Inputs inputs)
        {
            _context.Inputs.Add(inputs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInputs", new { id = inputs.Inputid }, inputs);
        }

        // DELETE: api/Inputs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inputs>> DeleteInputs(int id)
        {
            var inputs = await _context.Inputs.FindAsync(id);
            if (inputs == null)
            {
                return NotFound();
            }

            _context.Inputs.Remove(inputs);
            await _context.SaveChangesAsync();

            return inputs;
        }

        private bool InputsExists(int id)
        {
            return _context.Inputs.Any(e => e.Inputid == id);
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }

    }
}