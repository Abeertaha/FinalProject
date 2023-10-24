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
using Supplement.ViewModels.Category;

namespace Supplement.Controllers;

    [ApiController]
    [Route("[CategoryController]")]
    public class CategoryController: ControllerBase
    {
        private readonly DbConnection _connection;
        public CategoryController (DbConnection connection)
        {
            _connection = connection;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryVM>> Get()
        {
            var categories = await _connection.Categories.ToListAsync();
            return categories.Select(p=> new CategoryVM
           {
                Id = p.Id,
                Name = p.Name,
                }).ToList();
        }

            [HttpPost]
            public async Task<IActionResult> Post(CreateCategoryVM categoryVM)
            {
                var category= new Category{
                    Name = categoryVM.Name,
                    };
                
                await _connection.Categories.AddAsync(category);
                await _connection.SaveChangesAsync();
                return Ok(category);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var category = await _connection.Categories.FindAsync(id);
              _connection.Categories.Remove(category);
             await _connection.SaveChangesAsync();
             return Ok();
            }
    }