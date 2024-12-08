using Hospital.Models;

namespace Hospital.Services
{
    public interface IPatientService
    {
        string AddPatient(Patient patient);
        List<Patient> GetAllPatient();
    }
}