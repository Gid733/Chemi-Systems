using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChemiSystems.Infrastructure.Entities
{
    public class Item
    {
        [Key]
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public string DescriptionMain { get; set; }
        public string DescriptionSecondary { get; set; }        
        public double Price { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateChanged { get; set; }

        public ItemImage Image { get; set; }
        public virtual ItemCategory Category { get; set; }

        public Item()
        {
            DateAdded = DateTime.Now;
        }
    }
}