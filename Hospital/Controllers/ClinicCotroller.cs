using Hospital.Models;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClinicCotroller: ControllerBase
    {
        private readonly IClinicService _clinicService;
        public ClinicCotroller(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }
        [HttpGet("GetAllClinic")]
        public IActionResult GetAllClinic()
        {
            try
            {
                var clinics = _clinicService.GetAllClinic();
                return Ok(clinics);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Add(string Specialization,int No)
        {
            try
            {
                string NewClinic = _clinicService.AddClinic(new Clinic
                {
                 Specialization = Specialization,
                 NoOfSlots = No
    
                });
                return Created(string.Empty, NewClinic);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
