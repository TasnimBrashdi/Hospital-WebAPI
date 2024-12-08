using Hospital.Models;

namespace Hospital.Repositories
{
    public class BookingRepositorycs : IBookingRepositorycs
    {
        private readonly ApplicationDbContext _context;

        public BookingRepositorycs(ApplicationDbContext context)
        {
            _context = context;
        }
        public Booking GetByClinic(int cid)
        {
            return _context.Bookings.FirstOrDefault(c => c.ClinicId == cid);
        }

        public Booking GetByPatient(int pid)
        {
            return _context.Bookings.FirstOrDefault(p => p.PatientID == pid);
        }

        public void Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public Booking GetByPatientAndClinic(int patientId, int clinicId, DateTime date)
        {
            return _context.Bookings.FirstOrDefault(b => b.PatientID == patientId && b.ClinicId == clinicId && b.Date.Date == date.Date);
        }

        public int BookingCount(int clinicId, DateTime date)
        {
            return _context.Bookings.Count(b => b.ClinicId == clinicId && b.Date.Date == date.Date);
        }

    }
}
