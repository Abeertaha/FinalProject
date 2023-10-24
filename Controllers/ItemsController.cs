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
using Supplement.ViewModels.Items;
using Supplement.ViewModels.Users;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.ComponentModel;

namespace Supplement.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ItemsController : ControllerBase
    {
        private readonly DbConnection _connection;
        public ItemsController(DbConnection connection)
        {
            _connection = connection;
        }

        [HttpGet]
        public async Task<IEnumerable<Items>> GetByCategory(string category) 
        {
            var items = await _connection.Items
            .Include(p => p.Subcategory)
            .Where(p => p.Subcategory.Category.Name == category)
            .ToListAsync();

            return items.Select(p => new Items
            {
                Name = p.Name,
                Id = p.Id,
                
                Subcategory = new Subcategory 
                {
                    Id = p.Subcategory.Id,
                    Name = p.Subcategory.Name,
                }
            }).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateItemsVM vm)
        {
        try
        {
        var item = new Items
        {
            Name = vm.Name,
        };
        _connection.Items.Add(item);
        await _connection.SaveChangesAsync();

        return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
        }
    }
}