using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChemiSystems.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DescriptionMain { get; set; }
        public string DescriptionSecondary { get; set; }
        public string ImageMain { get; set; }
        public string ImageMolecular { get; set; }
        public string ImageFormula { get; set; }
        public double Price { get; set; }
    }
}