using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO
{
    public class LoginResponseDto
    { 
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
    }
}
