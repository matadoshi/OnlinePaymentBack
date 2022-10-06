using DomainModels.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Service.DTO;
using Service.DTO.Account;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class EmailService : IEmailService
    {
       
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;

        public EmailService(IConfiguration config, UserManager<User> userManager)
        {
            _config = config;
            _userManager = userManager;
        }
        public void ForgotPassword(User user, string url, ForgotPasswordDto model)
        {
            throw new NotImplementedException();
        }
        public async Task SendEmailAsync(string mail, string username, string html, string content)
        {
            var emailConfig = _config.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            User appUser = await _userManager.FindByEmailAsync(mail);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailConfig.Title, emailConfig.From));
            message.To.Add(new MailboxAddress(appUser.FullName, appUser.Email));
            message.Subject = emailConfig.Subject;
            string emailBody = html;
            message.Body = new TextPart { Text = emailBody };
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(emailConfig.SmtpServer, emailConfig.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(emailConfig.Username, emailConfig.Password);
            smtp.Send(message);
            smtp.Disconnect(true);
        }
    }
}
