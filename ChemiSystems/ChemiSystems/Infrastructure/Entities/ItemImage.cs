using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChemiSystems.Infrastructure.Entities
{
    public class ItemImage
    {
        [Key]
        [ForeignKey("Item")]
        public Guid Id { get; set; }
        public string ImageMain { get; set; }
        public string ImageMolecular { get; set; }
        public string ImageFormula { get; set; }
    }
}