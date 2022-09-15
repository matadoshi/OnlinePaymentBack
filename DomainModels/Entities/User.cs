using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Entities
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
        public bool IsBlocked { get; set; }
    }
}
