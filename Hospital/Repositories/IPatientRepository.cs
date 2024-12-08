using Hospital.Models;

namespace Hospital.Repositories
{
    public interface IPatientRepository
    {
        string Add(Patient patient);
        IEnumerable<Patient> GetAll();
    }
}