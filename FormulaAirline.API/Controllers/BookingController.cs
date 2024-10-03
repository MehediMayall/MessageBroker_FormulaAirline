using FormulaAirline.API.Models;
using FormulaAirline.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API;


[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase{
    private readonly IMessageProducer messageProducer;

    // In-Memory DB
    public static readonly List<Booking> bookings = new();

    public BookingController(IMessageProducer messageProducer)
    {
        this.messageProducer = messageProducer;
    }

    [HttpPost("/api/bookings")]
    public IActionResult CreatingBooking(Booking newBooking){
        if (!ModelState.IsValid) return BadRequest();

        bookings.Add(newBooking);
        messageProducer.SendMessage<Booking>(newBooking);

        return Ok();
    }
}