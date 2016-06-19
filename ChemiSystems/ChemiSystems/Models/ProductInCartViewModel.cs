using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChemiSystems.Infrastructure.Entities;

namespace ChemiSystems.Models
{
    public class ProductInCartViewModel
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}