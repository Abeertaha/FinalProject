using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supplement.Models;

namespace Supplement.Models
{
    public class Basket
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public Users users { get; set; }
    }
}