using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ChemiSystems.Infrastructure.Entities;
using ChemiSystems.Models;

namespace ChemiSystems.Infrastructure
{
    public class ChemiContext: DbContext
    {
        public ChemiContext()
            : base("ChemiDb")
        {
        }

        public DbSet<Order> Orders  { get; set; }
        public DbSet<Product> Products { get; set; } 
        public DbSet<ProductCategory> ProductCategories { get; set; }  
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductInOrder> ProductInOrder { get; set; }
    }
}