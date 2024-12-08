using Hospital.Models;

namespace Hospital.Services
{
    public interface IPatientService
    {
        void AddPatient(Patient patient);
        List<Patient> GetAllPatient();
    }
}