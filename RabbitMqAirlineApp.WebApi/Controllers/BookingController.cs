using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMqAirlineApp.WebApi.Models;
using RabbitMqAirlineApp.WebApi.Services;

namespace RabbitMqAirlineApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IMessageProducer _messageProducer;

        private static readonly List<Booking> bookings = new();

        public BookingController(ILogger<BookingController> logger, IMessageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
            if (!ModelState.IsValid) return BadRequest();

            bookings.Add(booking);

            _messageProducer.SendingMessage<Booking>(booking);

            return Ok();
        }
    }
}
