using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ChemiSystems.Infrastructure.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public string DescriptionMain { get; set; }
        public string DescriptionSecondary { get; set; }        
        public double Price { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateChanged { get; set; }
        public IdentityUser CreatedBy { get; set; }
        public IdentityUser ChangedBy { get; set; }

        public ProductImage Image { get; set; }
        public virtual ProductCategory Category { get; set; }

        public Product()
        {
            DateAdded = DateTime.Now;
        }
    }
}