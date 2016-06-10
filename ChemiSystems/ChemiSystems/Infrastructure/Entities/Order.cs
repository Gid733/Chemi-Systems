using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemiSystems.Infrastructure.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public double FinalPrice { get; set; }
        public DateTime OrderTime { get; set; }
    }
}