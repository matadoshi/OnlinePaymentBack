using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.PaymentModels
{
    public class Attributes:BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string SubscriberCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FIN { get; set; }
        public string AccountNumber { get; set; }
    }
}
