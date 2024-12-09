using Hospital.Models;

namespace Hospital.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly ApplicationDbContext _context;

        public ClinicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Clinic> GetAll()
        {
            return _context.Clinics.ToList();
        }

        public string Add(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            _context.SaveChanges();

            return clinic.Specialization;
        }
        public int SlotsCount(int slots)
        {
            return _context.Clinics.Count(b => b.NoOfSlots== slots) ;
        }
    }
}
