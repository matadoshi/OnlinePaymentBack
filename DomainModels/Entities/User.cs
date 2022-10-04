using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Entities
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsBlocked { get; set; }
        public ICollection<Card>Cards{ get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
