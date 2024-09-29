using Clinic_Appointment_System_API.Data;
using Clinic_Appointment_System_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Appointment_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        public DoctorController(ClinicDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetAllDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();


            return Ok(doctors);
        }
    }
}
