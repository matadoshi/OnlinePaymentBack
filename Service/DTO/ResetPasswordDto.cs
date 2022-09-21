using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO
{
    public class ResetPasswordDto
    {
        public string Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
