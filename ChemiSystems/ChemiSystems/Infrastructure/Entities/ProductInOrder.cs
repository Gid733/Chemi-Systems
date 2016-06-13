using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChemiSystems.Infrastructure.Entities
{
    public class ProductInOrder : Product
    {
        public int Quantity { get; set; }
    }
}