using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supplement.Models;
using Supplement.ViewModels;


namespace Supplement.DataAccess
{
    public class DbConnection : DbContext
    {
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Subcategory> SubCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Users> Users { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost port=5432 dbname=postgres user=postgres password=At@0799154444 sslmode=prefer connect_timeout=10");
    }
}
}