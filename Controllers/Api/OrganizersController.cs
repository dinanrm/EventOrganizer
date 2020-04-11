using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventOrganizer.Data;
using EventOrganizer.Models;
using Microsoft.AspNetCore.Authorization;

namespace EventOrganizer.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizersController : ControllerBase
    {
        private readonly EventOrganizerDbContext _context;

        public OrganizersController(EventOrganizerDbContext context)
        {
            _context = context;
        }

        // GET: api/Organizers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organizer>>> GetOrganizer()
        {
            return await _context.Organizer.ToListAsync();
        }

        // GET: api/Organizers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organizer>> GetOrganizer(Guid id)
        {
            var organizer = await _context.Organizer.FindAsync(id);

            if (organizer == null)
            {
                return NotFound();
            }

            return organizer;
        }

        // PUT: api/Organizers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizer(Guid id, Organizer organizer)
        {
            if (id != organizer.Id)
            {
                return BadRequest();
            }

            _context.Entry(organizer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizerExists(id))
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

        // POST: api/Organizers
        [HttpPost]
        public async Task<ActionResult<Organizer>> PostOrganizer(Organizer organizer)
        {
            _context.Organizer.Add(organizer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrganizerExists(organizer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrganizer", new { id = organizer.Id }, organizer);
        }

        // DELETE: api/Organizers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Organizer>> DeleteOrganizer(Guid id)
        {
            var organizer = await _context.Organizer.FindAsync(id);
            if (organizer == null)
            {
                return NotFound();
            }

            _context.Organizer.Remove(organizer);
            await _context.SaveChangesAsync();

            return organizer;
        }

        private bool OrganizerExists(Guid id)
        {
            return _context.Organizer.Any(e => e.Id == id);
        }
    }
}
