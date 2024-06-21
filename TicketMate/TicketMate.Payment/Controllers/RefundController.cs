using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace TicketMate.Payment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefundController : Controller
    {
            [HttpPost("refund-payment")]
            public async Task<IActionResult> RefundPayment([FromBody] RefundRequest request)
            {
                  var paymentIntentService = new PaymentIntentService();
                  var service = new RefundService();

                try
                {
                var paymentIntent = await paymentIntentService.GetAsync(request.PaymentId);
                if (paymentIntent == null)
                {
                    return NotFound(new { error = "PaymentIntent not found." });
                }
                var paymentCreationTime = paymentIntent.Created;

                // Check if the payment was created within the last 24 hours
                var timeElapsed = DateTime.UtcNow - paymentCreationTime;
                if (timeElapsed > TimeSpan.FromHours(24))
                {
                    return BadRequest(new { error = "Refund request time has expired. Refunds are only allowed within 24 hours of payment." });
                }
                var refundOptions = new RefundCreateOptions
                    {
                        PaymentIntent = request.PaymentId,
                    };

                    var refund = await service.CreateAsync(refundOptions);
                    DateTime refundCreationTime = refund.Created;  

                // Prepare the response with payment ID and refund date
                var response = new
                    {
                        refundId = refund.Id,
                        paymentId = refund.PaymentIntentId,
                        refundDate = refundCreationTime
                    };

                    return Ok(response);
                }
                catch (StripeException e)
                {
                    return BadRequest(new { error = e.StripeError.Message });
                }
            }
        }

        public class RefundRequest
        {
            public string PaymentId { get; set; }
        }
    }

