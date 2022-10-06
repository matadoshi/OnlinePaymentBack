using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO.Account
{
    public class AccountUpdateDto
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public DateTime Birthday { get; set; }
    }

}
