using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketMate.Payment.Data;
using TicketMate.Payment.DTOs;
using TicketMate.Payment.EmailService;
using TicketMate.Admin.Infastructure;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Identity.Client;


namespace TicketMate.Payment.Controllers
{
    // Specifying route and controller attributes for the API endpoint
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        // Declaring a private readonly field to hold an instance of the email service
        private readonly IEmailService emailService;
        // private readonly userDbContext dbContext;
        private readonly userDataDBContext dbContext;
        // private readonly userDbContext dbContext;

        // Constructor for the EmailController, injecting an instance of IEmailService
        public EmailController(IEmailService emailService, userDataDBContext dbContext)
        {
            this.emailService = emailService;
            this.dbContext = dbContext;

        }



        // HTTP POST endpoint for sending emails
        [HttpPost("SendEmails/{Id?}")]
        public ActionResult SendEmail(RequestDTO request, int Id)
        {

            var emailAddress = GetEmailAddress(Id); // Call the GET endpoint to get the email address
            // var emailAddress = "sandeepanirmh.21@uom.lk";

            // Assign the retrieved email address to the "To" property of the request DTO
            request.To = emailAddress.ToString();


            request.Message = GetMessage(Id);


            // Calling the SendEmail method of the injected email service
            var result = emailService.SendEmail(request);

            // Returning an HTTP response indicating success with a message
            return Ok("Mail sent!");
        }
        private string GetEmailAddress(int Id)
        {
            // Retrieve the user from the database where FirstName is "shanuka"
            //var user = dbContext.Users.FirstOrDefault(u => u.FirstName == "himasha");
            //var user= dbContext.users.FirstOrDefault(u => u.FirstName == "himasha");

            // var user = dbContext.Users.Where(u => u.FirstName == "himasha").SingleOrDefault();
            // return user != null ? user.Email : string.Empty;


            // If the user is found, return their email address; otherwise, return an empty string

            var user = dbContext.Users.Find(Id);
            return user != null ? user.Email : string.Empty;

        }
        private string GetMessage(int Id)
        {
            // Retrieve the user from the database where FirstName is "shanuka"
            // var user = dbContext.Users.FirstOrDefault(u => u.FirstName == "himasha");
            var user = dbContext.Users.Find(Id);

            // If the user is found, return their email address; otherwise, return an empty string
            return user != null ? " your payment receip is attached" : string.Empty;
        }


    }
}

