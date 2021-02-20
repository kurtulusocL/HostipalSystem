using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Entities.Models
{
    public class Departman:BaseHome
    {
        public string Name { get; set; }

        public ICollection<Patient> Patients { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Nurse> Nurses { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
