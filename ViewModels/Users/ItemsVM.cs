using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplement.ViewModels.Users
{
    public class ItemsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SubcategoryVM Subcategory { get; set; }
    }
}