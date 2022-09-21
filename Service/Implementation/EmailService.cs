using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Implementation
{
    public class EmailService : IEmailService
    {
        public void SenderEmail(RegisterDto model, string link)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Hesab.AZ", "juanmvcproject@gmail.com"));
            message.To.Add(new MailboxAddress(model.FullName, model.Email));
            message.Subject = "Confirmation Email";

            string emailbody = "<a href='[URL]'>Confirmation Link</a>".Replace("[URL]", link);
            using var smtp = new SmtpClient();
            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("juanmvcproject@gmail.com", "vuoilgkedltuysif");
            smtp.Send(message);
            smtp.Disconnect(true);
        }
    }
}
