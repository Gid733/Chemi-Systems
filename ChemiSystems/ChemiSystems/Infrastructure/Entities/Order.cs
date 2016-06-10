using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemiSystems.Infrastructure.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public double FinalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}