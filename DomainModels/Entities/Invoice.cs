using DomainModels.PaymentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Entities
{
    public class Invoice:BaseEntity
    {
        public int AttributeId { get; set; }
        public Attributes Attribute{ get; set; }
        public bool IsPaid { get; set; }
        public string UserId{ get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public Transaction Transaction{ get; set; }
    }
}
