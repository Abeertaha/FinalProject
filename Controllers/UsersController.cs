using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Supplement.Models;
using Supplement.ViewModels;
using Microsoft.EntityFrameworkCore;
using Supplement.DataAccess;
using Supplement.ViewModels.Users;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Supplement.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly DbConnection _connection;
        public UsersController(DbConnection connection)
        {
            _connection = connection;
        }

        [HttpGet]
        public async Task<IEnumerable<Users>> Get()
        {
            var usersList = await _connection.Set<Users>().ToListAsync();
            return usersList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id)
        {
            var user = await _connection.Set<Users>().FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult> Post(UsersVM vm)
        {
            var user = new Users
            {
                Name = vm.Name,
                Id = vm.Id,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
            };

            _connection.Set<Users>().Add(user);
            await _connection.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UsersVM vm)
        {
            var user = await _connection.Set<Users>().FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = vm.Name;
            user.Id = vm.Id;
            user.Email = vm.Email;
            user.PhoneNumber = vm.PhoneNumber;

            await _connection.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _connection.Set<Users>().FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _connection.Set<Users>().Remove(user);
            await _connection.SaveChangesAsync();

            return NoContent();
        }
    }
}