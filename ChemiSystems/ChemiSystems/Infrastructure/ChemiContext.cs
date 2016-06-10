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
            public DbSet<Item> Items { get; set; }
            public DbSet<ItemCategory> ItemCategories { get; set; } 
            public DbSet<ItemImage> ItemImages { get; set; }        
    }
}