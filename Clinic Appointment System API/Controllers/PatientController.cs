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

        [HttpPost]
        public async Task<ActionResult<List<Patient>>> CreatePatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return Ok(await _context.Clinics.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Patient>>> UpdatePatient(int id, Patient updatedPatient)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            // Update the patient properties
            patient.FirstName = updatedPatient.FirstName;
            patient.LastName = updatedPatient.LastName;
            patient.DateOfBirth = updatedPatient.DateOfBirth;
            patient.Gender = updatedPatient.Gender;
            patient.PhoneNumber = updatedPatient.PhoneNumber;
            patient.Email = updatedPatient.Email;
            patient.Address = updatedPatient.Address;
            patient.AppointmentId = updatedPatient.AppointmentId;
            patient.Appointments = updatedPatient.Appointments;

            await _context.SaveChangesAsync();

            return Ok(await _context.Patients.ToListAsync());
        }

    }
}
