using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketMate.Payment.Data;
using TicketMate.Payment.DTOs;
using TicketMate.Payment.EmailService;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Identity.Client;


namespace TicketMate.Payment.Controllers
{
    // Specifying route and controller attributes for the API endpoint
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
       
        private readonly IEmailService emailService;
        private readonly userDataDBContext dbContext;
        public EmailController(IEmailService emailService, userDataDBContext dbContext)
        {
            this.emailService = emailService;
            this.dbContext = dbContext;

        }

        [HttpPost("SendEmails/{Id?}")]
        public ActionResult SendEmail(RequestDTO request, int Id)
        {

            var emailAddress = GetEmailAddress(Id); 
            request.To = emailAddress.ToString();
           // request.Message = GetMessage(Id);


           
            var result = emailService.SendEmail(request);
            return Ok("Mail sent!");
        }
        private string GetEmailAddress(int Id)
        {
            var user = dbContext.Users.Find(Id);
            return user != null ? user.Email : string.Empty;

        }
        private string GetMessage(int Id)
        {
           
            var user = dbContext.Users.Find(Id);
            return user != null ? " your payment receip is attached" : string.Empty;
        }


    }
}

