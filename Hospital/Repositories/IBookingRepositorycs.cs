using Hospital.Models;

namespace Hospital.Repositories
{
    public interface IBookingRepositorycs
    {
        void Add(Booking booking);
        int BookingCount(int clinicId, DateTime date);
    
        IEnumerable<Booking> GetByClinic(int cid);
        IEnumerable<Booking> GetByPatient(int pid);
        Booking GetByPatientAndClinic(int patientId, int clinicId, DateTime date);
        List<Booking> GetByName(string name);
    }
}