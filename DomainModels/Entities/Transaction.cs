using DomainModels.Enum;
using DomainModels.PaymentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Entities
{
    public class Transaction:BaseEntity
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public string StatusId { get; set; }
        public string OrderId { get; set; }
        public OrderStatus OrderStatus{ get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
