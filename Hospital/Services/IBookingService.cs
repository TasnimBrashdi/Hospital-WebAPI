using Hospital.Models;

namespace Hospital.Services
{
    public interface IBookingService
    {
        void AddBooking(Booking bookings,Clinic clinic);
        Booking GetBookingByIdClinic(int id);
        Booking GetBookingByIdPatient(int id);
        List<Booking> GetByName(string name);
    }
}