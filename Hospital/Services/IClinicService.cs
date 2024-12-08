using Hospital.Models;

namespace Hospital.Services
{
    public interface IClinicService
    {
        void AddCALLClinic(Clinic clinic);
        List<Clinic> GetAllClinic();
    }
}