using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Entities.Models
{
    public class PatientInformation : BaseHome
    {
        public string Province { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}
