using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using TicketMate.Payment.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
//using TicketMate.Payment.Application.EmailServices;
//using Microsoft.EntityFrameworkcore;


//using Castle.Core.Configuration;

namespace TicketMate.Payment.EmailService //Defines a namespace for the EmailService class
{
    public class EmailService : IEmailService //Defines a class EmailService that implements the IEmailService interface
    {
        private readonly IConfiguration config;

        public EmailService(IConfiguration config)
        {
            // Initialize the EmailService with IConfiguration dependency
            this.config = config;
        }

        // Method to send an email
        public string SendEmail(RequestDTO request)
        {
            try
            {
                // Create a new MimeMessage for composing the email
                var email = new MimeMessage();

                // Set the sender's email address
                email.From.Add(MailboxAddress.Parse(config.GetSection("EmailUserName").Value));

                // Set the recipient's email address
                email.To.Add(MailboxAddress.Parse(request.To));

                // Set the email subject
                email.Subject = request.Subject;

                // Set the email body as HTML text
                email.Body = new TextPart(TextFormat.Html) { Text = request.Message };

                // Create an instance of SmtpClient for sending the email
                using var smtp = new MailKit.Net.Smtp.SmtpClient();

                // Connect to the SMTP server with the specified host and port using StartTLS for security
                smtp.Connect(config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);

                // Authenticate with the SMTP server using the provided username and password
                smtp.Authenticate(config.GetSection("EmailUserName").Value, config.GetSection("EmailPassword").Value);

                // Send the composed email
                smtp.Send(email);

                // Disconnect from the SMTP server after sending the email
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
                return BadRequest("email is not send successfully " + ex);
            }

            // Return a success message
            return "Mail Sent";
        }

        private string BadRequest(string v)
        {
            throw new NotImplementedException();
        }
    }
}


