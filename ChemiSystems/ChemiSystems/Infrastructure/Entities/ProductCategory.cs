using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ChemiSystems.Infrastructure.Entities
{
    public class ProductCategory
    {
        [Key]
        [ForeignKey("Product")]
        public Guid Id { get; set; }
        public Categories CategoryName { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateChanged { get; set; }
        public IdentityUser CreatedBy { get; set; }
        public IdentityUser ChangedBy { get; set; }

        public ProductCategory()
        {
            DateAdded = DateTime.Now;
        }
    }

    public enum Categories
    {
        MineralAcids = 0,
        SulfonicAcids = 1,
        CarboxylicAcids = 2,
        HalogenatedAcids = 3,
        VinylogousAcids = 4,
        NucleicAcids = 5
    }
    
}
