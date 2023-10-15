using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplement.ViewModels.Items
{
    public class CreateItemsVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int SubCategoryId { get; set; }
    }
}