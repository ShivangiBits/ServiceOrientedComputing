using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly UserDBContext _context;

        public usersController(UserDBContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> Getusers()
        {
            return await _context.users.ToListAsync();
        }

        // GET: api/users/1
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var User = await _context.users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            _context.users.Add(User);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = User.UserId }, User);
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User User)
        {
            if (id != User.UserId)
            {
                return BadRequest();
            }

            _context.Entry(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var User = await _context.users.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }

            _context.users.Remove(User);
            await _context.SaveChangesAsync();

            return User;
        }

        private bool UserExists(int id)
        {
            return _context.users.Any(e => e.UserId == id);
        }
    }

}
