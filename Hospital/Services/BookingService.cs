using Hospital.Models;
using Hospital.Repositories;

namespace Hospital.Services
{
    public class BookingService : IBookingService
    {

        private readonly IBookingRepositorycs _bookingRepository;

        public BookingService(IBookingRepositorycs bookingRepository)
        {
            _bookingRepository = bookingRepository;

        }
        public Booking GetBookingByIdPatient(int id)
        {
            var booking = _bookingRepository.GetByPatient(id);
            if (booking == null)
            {
                throw new KeyNotFoundException("booking not found.");
            }
            return booking;
        }
        public Booking GetBookingByIdClinic(int id)
        {
            var booking = _bookingRepository.GetByClinic(id);
            if (booking == null)
            {
                throw new KeyNotFoundException("booking not found.");
            }
            return booking;
        }

        public void AddBooking(Booking bookings)
        {
            if (bookings.Date < DateTime.Now)
            {
                throw new ArgumentException("Appointment date cannot be in the past.");
            }
            var existingBooking = _bookingRepository.GetByPatientAndClinic(
               bookings.PatientID,
               bookings.ClinicId,
               bookings.Date


                );

            if (existingBooking != null)
            {
                throw new ArgumentException("The patient already has a booking in this clinic on the selected date.");
            }

            var dailyBookingCount = _bookingRepository.BookingCount(
                 bookings.ClinicId,
                 bookings.Date);

            if (dailyBookingCount >= 20)
            {
                throw new InvalidOperationException("The clinic has the maximum number of appointments for the selected date.");
            }
            var booking = new Booking
            {
                PatientID = bookings.PatientID,
                ClinicId = bookings.ClinicId,
                Date = bookings.Date,
                Slots_Number = bookings.Slots_Number + 1
            };


            _bookingRepository.Add(booking);
        }
    }
}
