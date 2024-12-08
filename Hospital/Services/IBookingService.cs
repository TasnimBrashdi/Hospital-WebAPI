using Hospital.Models;

namespace Hospital.Services
{
    public interface IBookingService
    {
        void AddBooking(Booking bookings);
        Booking GetBookingByIdClinic(int id);
        Booking GetBookingByIdPatient(int id);
        List<Booking> GetByName(string name);
    }
}