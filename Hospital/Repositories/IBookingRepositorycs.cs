using Hospital.Models;

namespace Hospital.Repositories
{
    public interface IBookingRepositorycs
    {
        void Add(Booking booking);
        Booking GetByClinic(int cid);
        Booking GetByPatient(int pid);
    }
}