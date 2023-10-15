using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplement.ViewModels.Users
{
    public class SubcategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryVM Category { get; set; }
    }
}