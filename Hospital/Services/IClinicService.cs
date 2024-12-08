using Hospital.Models;

namespace Hospital.Services
{
    public interface IClinicService
    {
        string AddClinic(Clinic clinic);
        List<Clinic> GetAllClinic();
    }
}