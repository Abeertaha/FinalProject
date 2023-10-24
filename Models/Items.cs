using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplement.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}