using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ChemiSystems.Infrastructure.Entities;
using ChemiSystems.Models;

namespace ChemiSystems.Infrastructure
{
    public class ChemiContext: ApplicationDbContext
    {
            public DbSet<Product> Items { get; set; }
            public DbSet<ProductCategory> ProductCategories { get; set; } 
            public DbSet<ProductImage> ProductImages { get; set; }        
    }
}