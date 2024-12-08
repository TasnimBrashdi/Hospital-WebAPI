using Hospital.Models;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PatientCotroller: ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientCotroller(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet("GetAllPatient")]
        public IActionResult GetAllPatient()
        {
            try
            {
                var patients = _patientService.GetAllPatient();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Add(string name,int age,Patient.GENDER gen)
        {
            try
            {
                string NewPatient = _patientService.AddPatient(new Patient
                {
                 Name=name,
                 Age=age,
                 gender=gen
                });
                return Created(string.Empty, NewPatient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
