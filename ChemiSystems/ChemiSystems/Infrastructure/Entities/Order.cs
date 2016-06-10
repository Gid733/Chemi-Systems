using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ChemiSystems.Infrastructure.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public double FinalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliverTo { get; set; }
        public IdentityUser OrderedBy { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
        }
    }
}