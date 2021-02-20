using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Entities.Models
{
    public class DoctorDegree:BaseHome
    {
        public string University { get; set; }
        public string Degree { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
