using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplement.ViewModels.Users
{
    public class BasketVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemsVM Items { get; set; }
    }
}