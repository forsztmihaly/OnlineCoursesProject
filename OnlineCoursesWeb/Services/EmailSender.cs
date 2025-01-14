﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OnlineCoursesWeb.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender()
        {

        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("onlinecourses.confirmation@gmail.com");
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = "<html><body> " + htmlMessage + "</body></html> ";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("onlinecourses.confirmation@gmail.com", "prnfpbnafzvxktvo"),
                EnableSsl = true
            };
            smtpClient.Send(message);
            return Task.CompletedTask;
        }
    }
}
