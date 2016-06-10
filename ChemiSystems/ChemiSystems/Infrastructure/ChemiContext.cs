using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ChemiSystems.Infrastructure.Entities;

namespace ChemiSystems.Infrastructure
{
    public class ChemiContext: DbContext
    {
            public ChemiContext()
                : base("ChemiDb")
            { }

            public DbSet<Item> Items { get; set; }
            public DbSet<ItemCategory> ItemCategories { get; set; } 
            public DbSet<ItemImage> ItemImages { get; set; } 
        
    }
}