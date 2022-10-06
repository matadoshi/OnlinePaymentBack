using DomainModels.Entities;
using DomainModels.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO.Payment
{
    public class PaymentPostDto
    {
        public Card Card{ get; set; }
        public string FullName{ get; set; }
        public double Amount { get; set; }
        public OrderStatus OrderStatus{ get; set; }
    }
}
