﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketMate.Payment.Data;
using TicketMate.Payment.DTOs;
using TicketMate.Payment.EmailService;
using TicketMate.Admin.Infastructure;

namespace TicketMate.Payment.Controllers
{
    // Specifying route and controller attributes for the API endpoint
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        // Declaring a private readonly field to hold an instance of the email service
        private readonly IEmailService emailService;
       //private readonly UserDataDBContext dbContext;
        private readonly userDbContext dbContext;

        // Constructor for the EmailController, injecting an instance of IEmailService
        public EmailController(IEmailService emailService, userDbContext dbContext)
        {
            this.emailService = emailService;
            this.dbContext = dbContext;

        }

        // HTTP GET endpoint to retrieve email address
        //[HttpGet("GetEmilAddress")]
        // public ActionResult<string> GetEmailAddress()
        //{
        //var name = dbContext.Users.FirstOrDefault(u => u.FirstName == "shanuka");

        // return Ok(name.Email);
        //}





        // HTTP POST endpoint for sending emails
        [HttpPost("SendEmails")]
        public ActionResult SendEmail(RequestDTO request)
        {
            var emailAddress = GetEmailAddress(); // Call the GET endpoint to get the email address
           // var emailAddress = "sandeepanirmh.21@uom.lk";

            // Assign the retrieved email address to the "To" property of the request DTO
            request.To = emailAddress.ToString();
                       
            request.Message = GetMessage();
          

            // Calling the SendEmail method of the injected email service
            var result = emailService.SendEmail(request);

            // Returning an HTTP response indicating success with a message
            return Ok("Mail sent!");
        }
        public IActionResult GetEmailAddress()
        {
            // Retrieve the user from the database where FirstName is "shanuka"
            //var user = dbContext.Users.FirstOrDefault(u => u.FirstName == "himasha");
            //var user= dbContext.users.FirstOrDefault(u => u.FirstName == "himasha");
            try
            {
                var user = dbContext.users.Where(u => u.FirstName == "himasha")
                    .Select(u => new { u.Email }).FirstOrDefault();
                if (user != null)
                {
                    return Ok(user);
                }
                return BadRequest("user not found");

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
          


            // If the user is found, return their email address; otherwise, return an empty string
            //return user != null ? user.Email : string.Empty;
           

        }
        private string GetMessage()
        {
            // Retrieve the user from the database where FirstName is "shanuka"
           // var user = dbContext.Users.FirstOrDefault(u => u.FirstName == "himasha");
           var user = dbContext.users.FirstOrDefault(u => u.FirstName == "himasha");

            // If the user is found, return their email address; otherwise, return an empty string
            return user != null ? user.OwnVehicleType + " your payment receip is attached" : string.Empty;
        }


    }
}