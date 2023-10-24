using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supplement.ViewModels.Users;

namespace Supplement.ViewModels
{
    public class AddToBasketVM
    {
        public int ProductId { get; set; }
        public int UserId { get; set;}
        public int Quantity { get; set; }
        public UsersVM Items { get; set; }
    }
}