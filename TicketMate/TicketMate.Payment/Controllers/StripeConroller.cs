using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace TicketMate.Payment.Api.Controllers
{
    [ApiController]
    [Route("api/stripe")]
    public class StripeController : ControllerBase
    {
        [HttpPost("create-payment-intent")]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] CreatePaymentIntentRequest request)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = request.Amount,
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" },
            };

            var service = new PaymentIntentService();
            try
            {
                var paymentIntent = await service.CreateAsync(options);
                var response = new
                {
                    clientSecret = paymentIntent.ClientSecret,
                    paymentId = paymentIntent.Id,
                    paymentDate = paymentIntent.Created,
                };  
                return Ok(response);
            }
            catch (StripeException e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
    }

    public class CreatePaymentIntentRequest
    {
        public long Amount { get; set; }
    }
}

