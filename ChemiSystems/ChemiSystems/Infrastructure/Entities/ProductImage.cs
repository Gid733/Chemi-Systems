using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ChemiSystems.Infrastructure.Entities
{
    public class ProductImage
    {
        [Key]
        [ForeignKey("Item")]
        public Guid Id { get; set; }
        public string ImageMain { get; set; }
        public string ImageMolecular { get; set; }
        public string ImageFormula { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateChanged { get; set; }
        public IdentityUser ChangedBy { get; set; }
        public IdentityUser CreatedBy { get; set; }

        public ProductImage()
        {
            DateAdded = DateTime.Now;
        }
    }
}