using System.ComponentModel.DataAnnotations;

namespace TicketMate.Payment.DTOs
{
    public class RequestDTO
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; }
        public string Message { get; set; } = string.Empty;


        // Constructor to set default value for Subject
        public RequestDTO()
        {

       
            Subject = "Your payment receipt"; // Set default value for Subject

        }
    }
}

