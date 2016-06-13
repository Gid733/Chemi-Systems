using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using ChemiSystems.Infrastructure.Base;

namespace ChemiSystems.Infrastructure.Entities
{
    public class ProductImage : BaseEntity
    {
        public string ImageMain { get; set; }
        public string ImageMolecular { get; set; }
        public string ImageFormula { get; set; }
    }
}