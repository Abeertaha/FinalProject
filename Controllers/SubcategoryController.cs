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
using Supplement.ViewModels.Subcategory;

namespace Supplement.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SubcategoryController : ControllerBase
    {
        private readonly DbConnection _connection;
        public SubcategoryController(DbConnection connection)
        {
            _connection = connection;
        }

        [HttpGet]
        public async Task<IEnumerable<Subcategory>> Get()
        {
            var subCategories = await _connection.SubCategories.Include(sc => sc.Category).ToListAsync();
            return subCategories.Select(sc => new Subcategory
            {
                Id = sc.Id,
                Name = sc.Name,
                CategoryId = sc.CategoryId,

                Category = new Category
                {
                    Id = sc.Category.Id,
                    Name = sc.Category.Name,
                }
            }).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSubcategoryVM vm)
        {
            var subcategory = new Subcategory
            {
                Name = vm.Name,
                CategoryId = vm.CategoryId,
            };

            _connection.SubCategories.Add(subcategory);
            await _connection.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subcategory = await _connection.SubCategories.FindAsync(id);
            _connection.SubCategories.Remove(subcategory);
            await _connection.SaveChangesAsync();

            return Ok();
        }
    }
}