using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController(IBookingService bookingService) : ControllerBase
{
    private readonly IBookingService _bookingService = bookingService;

    [HttpPost]
    public async Task<IActionResult> CreateBooking(CreateBookingRequest request)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _bookingService.CreateBookingAsync(request);
        return response.Success ? Ok(response) : BadRequest(response.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        var response = await _bookingService.GetAllBookingsAsync();
        return response.Success ? Ok(response) : NotFound(response.Error);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingById(string id)
    {
        var response = await _bookingService.GetBookingByIdAsync(id);
        return response.Success ? Ok(response) : NotFound(response.Error);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBooking(string id, UpdateBookingRequest request)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var response = await _bookingService.UpdateBookingAsync(id, request);
        return response.Success ? Ok(response) : NotFound(response.Error);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(string id)
    {
        var response = await _bookingService.DeleteBookingAsync(id);
        return response.Success ? Ok(response) : NotFound(response.Error);
    }
}
