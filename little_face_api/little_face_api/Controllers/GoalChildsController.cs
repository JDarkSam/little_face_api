using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using little_face_api.Data;
using little_face_api.Data.Models;

namespace little_face_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalChildsController : ControllerBase
    {
        private readonly little_face_DBContext _context;

        public GoalChildsController(little_face_DBContext context)
        {
            _context = context;
        }

        // GET: api/GoalChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalChild>>> GetGoalChilds()
        {
          if (_context.GoalChilds == null)
          {
              return NotFound();
          }
            return await _context.GoalChilds.Include(u => u.Child).ToListAsync();
        }

        // GET: api/GoalChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoalChild>> GetGoalChild(long id)
        {
          if (_context.GoalChilds == null)
          {
              return NotFound();
          }
            var goalChild = await _context.GoalChilds.FindAsync(id);

            if (goalChild == null)
            {
                return NotFound();
            }

            return goalChild;
        }

        // PUT: api/GoalChilds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoalChild(long id, GoalChild goalChild)
        {
            if (id != goalChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(goalChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalChildExists(id))
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

        // POST: api/GoalChilds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GoalChild>> PostGoalChild(GoalChild goalChild)
        {
          if (_context.GoalChilds == null)
          {
              return Problem("Entity set 'little_face_DBContext.GoalChilds'  is null.");
          }
            _context.GoalChilds.Add(goalChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoalChild", new { id = goalChild.Id }, goalChild);
        }

        // DELETE: api/GoalChilds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoalChild(long id)
        {
            if (_context.GoalChilds == null)
            {
                return NotFound();
            }
            var goalChild = await _context.GoalChilds.FindAsync(id);
            if (goalChild == null)
            {
                return NotFound();
            }

            _context.GoalChilds.Remove(goalChild);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GoalChildExists(long id)
        {
            return (_context.GoalChilds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
