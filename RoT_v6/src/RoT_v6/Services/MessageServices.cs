using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RoT_v6.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
   {
      

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // STEP 1: Navigate to this page https://www.google.com/settings/security/lesssecureapps & set to "Turn On"

            var mail = new MimeMessage();
            mail.From.Add(new MailboxAddress("Breedt Production Tooling and Design ", "BPTDAuthenticate@donotreply.com"));
            mail.To.Add(new MailboxAddress("New user", email));
            mail.Subject = "Welcome";
            mail.Body = new TextPart("plain")
            {
                Text = message
            };           

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587);               
                client.AuthenticationMechanisms.Remove("XOAUTH2");              
                await client.AuthenticateAsync("AllDotDat@gmail.com", "H}3~}Dg->XYt:KhF");
                await client.SendAsync(mail);
                await client.DisconnectAsync(true);
            }

        }

        public Task SendEmailAsync(string email, string subject, string message, string name)
        {
            throw new NotImplementedException();
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
