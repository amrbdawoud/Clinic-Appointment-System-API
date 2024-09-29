using Microsoft.EntityFrameworkCore;
using Clinic_Appointment_System_API.Entities;

namespace Clinic_Appointment_System_API.Data;

public class ClinicDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureAppointment(modelBuilder);
    }

    private void ConfigureAppointment(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(p => p.PatientId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Clinic)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.ClinicId);

        modelBuilder.Entity<Appointment>()
         .HasOne(a => a.Doctor)
         .WithMany(p => p.Appointments)
         .HasForeignKey(a => a.AppointmentId);

    }




}
