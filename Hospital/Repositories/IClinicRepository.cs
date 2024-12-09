using Hospital.Models;

namespace Hospital.Repositories
{
    public interface IClinicRepository
    {
        string Add(Clinic clinic);
        IEnumerable<Clinic> GetAll();
   
    }
}