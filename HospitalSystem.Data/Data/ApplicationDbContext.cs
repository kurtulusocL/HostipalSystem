using HospitalSystem.Data.Identity;
using HospitalSystem.Entities.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Data.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext():base("DefaultConnection")
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorDegree> DoctorDegrees { get; set; }
        public DbSet<DoctorInformation> DoctorInformations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeInformation> EmployeeInformations { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<NurseDegree> NurseDegrees { get; set; }
        public DbSet<NurseInformation> NurseInformations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<PatientRoom> PatientRooms { get; set; }
        public DbSet<PatientInformation> PatientInformations { get; set; }
    }
}
