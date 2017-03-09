// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="MessageServices.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace RoT_v6.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    /// <summary>
    /// Class AuthMessageSender.
    /// </summary>
    /// <seealso cref="RoT_v6.Services.IEmailSender" />
    /// <seealso cref="RoT_v6.Services.ISmsSender" />
    public class AuthMessageSender : IEmailSender, ISmsSender
   {


        /// <summary>
        /// send email as an asynchronous operation.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <returns>Task.</returns>
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // Documentation for Mimekit http://www.mimekit.net/docs/html/CreatingMessages.htm
            // for this we need to change security of the sending account https://www.google.com/settings/security/lesssecureapps 

            var mail = new MimeMessage();
            mail.From.Add(new MailboxAddress("Breedt Production Tooling and Design "));
            mail.To.Add(new MailboxAddress("New user", email));
            mail.Subject = "Welcome";
            mail.Body = new TextPart("plain")
            {
                Text = message
            };           

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587);
                //since we are connecting to a gmail account and don't have authentication token
                //we remove the authentication mechanism               
                client.AuthenticationMechanisms.Remove("XOAUTH2");              
                await client.AuthenticateAsync("AllDotDat@gmail.com", "H}3~}Dg->XYt:KhF");
                await client.SendAsync(mail);
                await client.DisconnectAsync(true);
            }

        }

        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <param name="name">The name.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task SendEmailAsync(string email, string subject, string message, string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends the SMS asynchronous.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="message">The message.</param>
        /// <returns>Task.</returns>
        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
