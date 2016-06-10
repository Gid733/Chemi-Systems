using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChemiSystems.Infrastructure.Entities
{
    public class ItemCategory
    {
        [Key]
        [ForeignKey("Item")]
        public Guid Id { get; set; }
        public Categories Category { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateChanged { get; set; }
        public string ChangedBy { get; set; }

        public ItemCategory()
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
