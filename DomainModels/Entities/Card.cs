using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Entities
{
    public class Card:BaseEntity
    {
        public string Number { get; set; }
        public string ExpirationDate { get; set; }
        public byte CVV { get; set; }
        public string UserId { get; set; }
        public User User { get; }
    }
}
