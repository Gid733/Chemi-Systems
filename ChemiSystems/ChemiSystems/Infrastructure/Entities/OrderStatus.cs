using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChemiSystems.Infrastructure.Base;

namespace ChemiSystems.Infrastructure.Entities
{
    public class OrderStatus : BaseEntity
    {
        public string Status { get; set; }
        public string StatusColor { get; set; }
        public string StatusIcon { get; set; }
        public ICollection<Order> Orders { get; set; }

        public OrderStatus()
        {
            Status = "Archived";
            StatusColor = "btn btn-success";
            StatusIcon = "fa fa-credit-card";
        }
    }
}