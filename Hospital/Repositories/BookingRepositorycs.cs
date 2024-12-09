using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Hospital.Repositories
{
    public class BookingRepositorycs : IBookingRepositorycs
    {
        private readonly ApplicationDbContext _context;

        public BookingRepositorycs(ApplicationDbContext context)
        {
            _context = context;
        }
        //public Booking GetByClinic(int cid)
        //{
        //    return _context.Bookings.FirstOrDefault(c => c.ClinicId == cid);
        //}
        public IEnumerable<Booking> GetByClinic(int cid)
        {
            return _context.Bookings.Where(p => p.ClinicId == cid).ToList();
        }

        public IEnumerable<Booking> GetByPatient(int pid)
        {
            return _context.Bookings.Where(p => p.PatientID == pid).ToList();
        }


        public void Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }
        public List<Booking> GetByName(string name)
        {
            return _context.Bookings
                .Include(b => b.Patient)
                .Include(b => b.Clinic)
                .Where(b => b.Patient.Name.Contains(name))
                .ToList();
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
