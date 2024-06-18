using CrudOperation.Models.Domain;
using CrudOperation.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        private readonly UserService _userService;

        public CrudOperationController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            _userService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            var existingUser = _userService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _userService.UpdateUser(id, user.Username, user.Text);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingUser = _userService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}