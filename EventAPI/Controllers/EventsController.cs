using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventAPI.Data;
using EventAPI.Models;
using Microsoft.AspNetCore.Authorization;
using EventAPI.Authentication;

namespace EventAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDTO>>> GetEvents()
        {
            return await _context.Events
                .Select(e => new EventDTO
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    StartTime = e.StartTime,
                    UserId = e.UserId
                })
                .ToListAsync();
        }

        // GET: api/Events/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDTO>> GetEvent(Guid id)
        {
            var eventEntity = await _context.Events
                .Include(e => e.User) // Eager Loading
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventEntity == null)
            {
                return NotFound();
            }

            var eventDTO = new EventDTO
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                StartTime = eventEntity.StartTime,
                UserId = eventEntity.UserId,
                User = eventEntity.User == null ? null : new UserDTO
                {
                    Id = eventEntity.User.Id,
                    UserName = eventEntity.User.UserName,
                    Email = eventEntity.User.Email
                }
            };

            return Ok(eventDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(Guid id, EventDTO eventDTO)
        {
            if (id != eventDTO.Id)
            {
                return BadRequest("Event ID in the URL does not match the ID in the body.");
            }

            // Fetch the existing event from the database
            var eventEntity = await _context.Events.Include(e => e.User).FirstOrDefaultAsync(e => e.Id == id);

            if (eventEntity == null)
            {
                return NotFound($"Event with ID '{id}' not found.");
            }

            // Fetch the user from the database using the UserId provided in the DTO
            var user = await _context.Users.FindAsync(eventDTO.UserId);
            if (user == null)
            {
                return BadRequest($"User with ID '{eventDTO.UserId}' does not exist.");
            }

            // Update the event properties
            eventEntity.Title = eventDTO.Title;
            eventEntity.Description = eventDTO.Description;
            eventEntity.StartTime = eventDTO.StartTime;
            eventEntity.UserId = eventDTO.UserId; // Update the foreign key
            eventEntity.User = user;             // Update the navigation property

            // Save changes to the database
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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



        [HttpPost]
        public async Task<ActionResult<EventDTO>> PostEvent(EventDTO eventDTO)
        {
            // Fetch the user from the database using the UserId provided in the DTO
            var user = await _context.Users.FindAsync(eventDTO.UserId);

            if (user == null)
            {
                return BadRequest($"User with ID '{eventDTO.UserId}' does not exist.");
            }

            // Create a new Event entity and assign the fetched user to the User property
            var eventEntity = new Event
            {
                Id = Guid.NewGuid(),
                Title = eventDTO.Title,
                Description = eventDTO.Description,
                StartTime = eventDTO.StartTime,
                UserId = eventDTO.UserId, // Foreign key
                User = user               // Navigation property
            };

            // Add the event to the database
            _context.Events.Add(eventEntity);
            await _context.SaveChangesAsync();

            // Return the created event as a DTO
            return CreatedAtAction(nameof(GetEvent), new { id = eventEntity.Id }, eventDTO);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            // Fetch the event from the database
            var eventEntity = await _context.Events.FindAsync(id);

            if (eventEntity == null)
            {
                return NotFound($"Event with ID '{id}' not found.");
            }

            // Remove the event
            _context.Events.Remove(eventEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Helper method to check if an event exists
        private bool EventExists(Guid id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
