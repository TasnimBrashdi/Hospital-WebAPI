using Hospital.Models;
using Hospital.Repositories;

namespace Hospital.Services
{
    public class BookingService : IBookingService
    {

        private readonly IBookingRepositorycs _bookingRepository;
        private readonly IClinicRepository _clinicRepository;
        public BookingService(IBookingRepositorycs bookingRepository, IClinicRepository clinicRepository)
        {
            _bookingRepository = bookingRepository;
            _clinicRepository = clinicRepository;

        } 
        public List<Booking> GetBookingByIdPatient(int id)
        {
            var booking = _bookingRepository.GetByPatient(id).ToList(); ;
            if (booking == null)
            {
                throw new KeyNotFoundException("booking not found.");
            }
            return booking;
        }
        public List<Booking>  GetBookingByIdClinic(int id)
        {
            var booking = _bookingRepository.GetByClinic(id).ToList();
            if (booking == null)
            {
                throw new KeyNotFoundException("booking not found.");
            }
            return booking;
        }
        public List<Booking> GetByName(string name) {

            var booking = _bookingRepository.GetByName(name);
            if (booking == null)
            {
                throw new KeyNotFoundException("booking not found.");
            }
            return booking;
        }
     
        public void AddBooking(Booking bookings,Clinic clinic)
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
            var availableSlots = clinic.NoOfSlots;
          
            var BookingDaily = _bookingRepository.BookingCount(
        
                bookings.ClinicId,
                bookings.Date
                
                );

            if (BookingDaily > availableSlots)
            {
                throw new InvalidOperationException("The clinic has the maximum number of appointments for the selected date.");
            }

            var booking = new Booking
            {
                PatientID = bookings.PatientID,
                ClinicId = bookings.ClinicId,
                Date = bookings.Date,
                Slots_Number = BookingDaily + 1
            };


            _bookingRepository.Add(booking);
        }
    }
}
