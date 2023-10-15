using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}