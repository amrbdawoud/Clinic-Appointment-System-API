using Clinic_Appointment_System_API.Data;
using Clinic_Appointment_System_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Clinic_Appointment_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        public PatientController(ClinicDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetAllPatients()
        {
            var patients = await _context.Patients.ToListAsync();

            
            return Ok(patients);
        }
    }
}
