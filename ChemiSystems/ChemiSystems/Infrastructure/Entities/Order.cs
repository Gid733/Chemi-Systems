using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using ChemiSystems.Infrastructure.Base;

namespace ChemiSystems.Infrastructure.Entities
{
    public class Order : BaseEntity
    {
        //public virtual ICollection<ProductInOrder> ProductsInOrder { get; set; }
        public DateTime DeliverToDate { get; set; }
        public string DeliverToAddress { get; set; }
        public Guid OrderedBy { get; set; }       
    }
}