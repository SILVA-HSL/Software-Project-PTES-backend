using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using TicketMate.Payment.DTOs;
using Microsoft.Extensions.Configuration;


//using Castle.Core.Configuration;

namespace TicketMate.Payment.EmailService
{
    public class EmailService : IEmailService
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
                email.To.Add(MailboxAddress.Parse(request.To)); // Fix the error by using the correct property name

                // Set the email subject
                email.Subject = request.Subject;

                // Set the email body as HTML text
                email.Body = new TextPart(TextFormat.Html) { Text = request.Message };

                // Create an instance of SmtpClient for sending the email
                using var smtp = new MailKit.Net.Smtp.SmtpClient(); // Fix the error by using the fully qualified name

                // Connect to the SMTP server with the specified host and port using StartTLS for security
                smtp.Connect(config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);

                // Authenticate with the SMTP server using the provided username and password
                smtp.Authenticate(config.GetSection("EmailUserName").Value, config.GetSection("EmailPassword").Value);

                // Send the composed email
                smtp.Send(email);

                // Disconnect from the SMTP server after sending the email
                smtp.Disconnect(true);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }

            // Return a success message
            return "Mail Sent";
        }
    }
}

