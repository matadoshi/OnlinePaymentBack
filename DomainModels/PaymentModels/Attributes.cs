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
    }
}
