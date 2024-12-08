using Hospital.Models;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BookingCotroller: ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingCotroller(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("GetBookingByPatient/{pid}")]
        public IActionResult GetBookingByIdPatient(int pid)
        {
            try
            {
                var booking = _bookingService.GetBookingByIdPatient(pid);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetBookingByIdClinic/{cid}")]
        public IActionResult GetBookingByIdClinic(int cid)
        {
            try
            {
                var booking = _bookingService.GetBookingByIdClinic(cid);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddBooking(int cid,int pid,DateTime dateTime,int no)
        {
            try
            {
                _bookingService.AddBooking(new Booking
                {
                    ClinicId = cid,
                    PatientID = pid,
                    Date= dateTime,
                    Slots_Number = no
                   
                });
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
