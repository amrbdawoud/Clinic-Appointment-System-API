﻿using Clinic_Appointment_System_API.Data;
using Clinic_Appointment_System_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Appointment_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        public ClinicController(ClinicDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Clinic>>> GetAllClinics()
        {
            var clinics = await _context.Clinics.ToListAsync();


            return Ok(clinics);
        }

        [HttpPost]
        public async Task<ActionResult<List<Clinic>>> CreateClinic(Clinic clinics)
        {
            _context.Clinics.Add(clinics);
            await _context.SaveChangesAsync();

            return Ok(await _context.Clinics.ToListAsync());
        }
    }
}