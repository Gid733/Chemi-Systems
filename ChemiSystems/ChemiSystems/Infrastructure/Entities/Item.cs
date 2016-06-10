using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChemiSystems.Infrastructure.Entities
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public string DescriptionMain { get; set; }
        public string DescriptionSecondary { get; set; }        
        public double Price { get; set; }

        public ItemImage Image { get; set; }
        public ItemCategory Category { get; set; }
    }
}