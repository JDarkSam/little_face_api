using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using little_face_api.Data;
using little_face_api.Data.Models;
using little_face_api.Data.Dto;
using Microsoft.Identity.Client;

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
        public async Task<ActionResult<IEnumerable<GoalChildDto>>> GetGoalChilds(long userId, long childId)
        {
            if (_context.GoalChilds == null)
            {
                return NotFound();
            }          

            var query = from gc in _context.GoalChilds
                        join c in _context.Childs on gc.ChildId equals c.Id
                        join g in _context.Goals on gc.GoalId equals g.Id
                        where gc.UserId == userId && gc.ChildId == childId
                        select new GoalChildDto
                        {
                            Id = gc.Id,
                            Face = gc.Face,
                            DateGoal = gc.DateGoal,
                            ChildId = gc.Id,
                            Alias = c.Alias,
                            GoalId = gc.GoalId,
                            Taskname = g.Taskname,
                            UserId = gc.UserId
                        };
            query.ToList();

            List<GoalChildDto> goalChildDto= new List<GoalChildDto>(query);

            return goalChildDto;
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
