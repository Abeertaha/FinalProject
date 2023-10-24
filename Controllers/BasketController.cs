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

namespace Supplement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly DbConnection _connection;
        public BasketController(DbConnection connection)
        {
            _connection = connection;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketItems(int userId)
        {
            try
            {
                var basketItems = await _connection.Baskets
                .Where(item => item.UserId == userId)
                .ToListAsync();

                return Ok(basketItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(AddToBasketVM vm)
        {
            try
            {
                var basketItem = new Basket
                {
                    UserId = vm.UserId,
                    ProductId = vm.ProductId,
                    Quantity = vm.Quantity
                };
                _connection.Baskets.Add(basketItem);
                await _connection.SaveChangesAsync();

                return CreatedAtAction("GetBasketItems", new { userId = vm.UserId }, basketItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}