using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ChemiSystems.Infrastructure.Entities
{
    public class ItemImage
    {
        [Key]
        [ForeignKey("Item")]
        public Guid ItemImageId { get; set; }
        public string ImageMain { get; set; }
        public string ImageMolecular { get; set; }
        public string ImageFormula { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateChanged { get; set; }
        public IdentityUser ChangedBy { get; set; }

        public ItemImage()
        {
            DateAdded = DateTime.Now;
        }
    }
}