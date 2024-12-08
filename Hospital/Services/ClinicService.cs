using Hospital.Models;
using Hospital.Repositories;

namespace Hospital.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicService(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;

        }
        public List<Clinic> GetAllClinic()
        {
            var clinics = _clinicRepository.GetAll().OrderBy(c => c.Specialization).ToList();
            if (clinics == null || clinics.Count == 0)
            {
                throw new InvalidOperationException("No clinics found.");
            }
            return clinics;
        }
        public string AddClinic(Clinic clinic)
        {
            if (clinic.Specialization == null)
            {
                throw new ArgumentException("Specialization  is required.");
            }

            return _clinicRepository.Add(clinic);
        }
    }
}
