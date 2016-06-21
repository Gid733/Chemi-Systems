using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ChemiSystems.Infrastructure.Base;
using ChemiSystems.Models;

namespace ChemiSystems.Infrastructure.Entities
{
    public class Order : BaseEntity
    {
        public ICollection<ProductInOrder> ProductsInOrder { get; set; }
        public DateTime? DeliverToDate { get; set; }
        public string DeliverToAddress { get; set; }
        public Guid? OrderedBy { get; set; }   
        public OrderStatus OrderStatus { get; set; }

        public Order()
        {
            OrderStatus = OrderStatus.WaitingForPayment;
        }
    }   
}