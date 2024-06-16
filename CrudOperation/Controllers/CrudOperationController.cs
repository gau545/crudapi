using CrudOperation.Data;
using CrudOperation.Models.Domain;
using CrudOperation.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CrudOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        private readonly CrudDbContext _context;

        public CrudOperationController(CrudDbContext db)
        {
            _context = db;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(CreateUserDTO req)
        {
            var user = new User
            {
                Username = req.Username,
                Text = req.Text,
                CreatedDate = req.CreatedDate
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("GetAllData")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPut("UpdateById/{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UpdateUserDTO req)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Username = req.Username;
            user.Text = req.Text;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
