using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ChemiSystems.Infrastructure.Base;

namespace ChemiSystems.Infrastructure.Entities
{
    public class PaymentTransaction : BaseEntity
    {       
        public string PaymentId { get; set; }
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public PaymentTransactionStatus PaymentStatus { get; set; }
        public PaymentTransactionAction PaymentAction { get; set; }
        public OperationType OperationType { get; set; }       
    }

    public enum PaymentTransactionAction
    {
        Deposit = 0,
        Withdrawal = 1
    }

    public enum PaymentTransactionStatus
    {
        Pending = 0,
        Success = 1,
        Failed = 2
    }

    public enum OperationType
    {
        Refund = 0,
        AddMoney = 1
    }
}