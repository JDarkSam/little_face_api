using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using little_face_api.Data;
using little_face_api.Data.Models;
using Microsoft.AspNetCore.Authorization;
using little_face_api.Data.Dto;

namespace little_face_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildsController : ControllerBase
    {
        private readonly little_face_DBContext _context;

        public ChildsController(little_face_DBContext context)
        {
            _context = context;
        }

        // GET: api/Childs
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Child>>> GetChildsByUser(long userId)
        {
            if (_context.Childs == null)
            {
                return NotFound();
            }          

            return await _context.Childs
                       .Where(p => p.UserId == userId)
                       .ToListAsync();

        }
 

        // GET: api/Childs/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Child>> GetChild(long id)
        {
          if (_context.Childs == null)
          {
              return NotFound();
          }
            var child = await _context.Childs.FindAsync(id);

            if (child == null)
            {
                return NotFound();
            }

            return child;
        }

        // PUT: api/Childs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutChild(long id, Child child)
        {
            if (id != child.Id)
            {
                return BadRequest();
            }

            _context.Entry(child).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChildExists(id))
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

        // POST: api/Childs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Child>> PostChild(ChildDto child)
        {
          if (_context.Childs == null)
          {
              return Problem("Entity set 'little_face_DBContext.Childs'  is null.");
          }


            Child Resultado = new Child()
            {
                UserId = child.UserId,
                Names = child.Names,
                Surnames = child.Surnames,
                Age = child.Age,
                Alias = child.Alias,
                User = this._context.Users.Where(x => x.Id == child.UserId).FirstOrDefault()
            };

            _context.Childs.Add(Resultado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChild", new { id = Resultado.Id }, Resultado);
        }

        // DELETE: api/Childs/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteChild(long id)
        {
            if (_context.Childs == null)
            {
                return NotFound();
            }
            var child = await _context.Childs.FindAsync(id);
            if (child == null)
            {
                return NotFound();
            }

            _context.Childs.Remove(child);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChildExists(long id)
        {
            return (_context.Childs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
