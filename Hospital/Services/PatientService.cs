using Hospital.Models;
using Hospital.Repositories;

namespace Hospital.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;

        }
        public List<Patient> GetAllPatient()
        {
            var patient = _patientRepository.GetAll().OrderBy(b => b.Name).ToList();
            if (patient == null || patient.Count == 0)
            {
                throw new InvalidOperationException("No patients found.");
            }
            return patient;
        }
        public string AddPatient(Patient patient)
        {
            if (patient.Name == null)
            {
                throw new ArgumentException("Patient name is required.");
            }

            return _patientRepository.Add(patient);
        }
    }
}
