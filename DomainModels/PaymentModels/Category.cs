using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.PaymentModels
{
    public class Category:BaseEntity
    {
        public List<Attributes> Attributes { get; set; }
    }
}
