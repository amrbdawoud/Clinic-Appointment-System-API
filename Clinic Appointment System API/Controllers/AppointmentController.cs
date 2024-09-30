using Clinic_Appointment_System_API.Data;
using Clinic_Appointment_System_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Appointment_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        public AppointmentController(ClinicDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> GetAllAppointments()
        {
            var appointments = await _context.Appointments.ToListAsync();


            return Ok(appointments);
        }

        [HttpPost]
        public async Task<ActionResult<List<Appointment>>> CreateAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Appointments.ToListAsync());
        }
    }
}

