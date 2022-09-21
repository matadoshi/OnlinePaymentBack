using Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IEmailService
    {
        void SenderEmail(RegisterDto model, string link);
    }
}
