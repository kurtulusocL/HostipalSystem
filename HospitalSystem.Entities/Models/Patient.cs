using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Entities.Models
{
    public class Patient:BaseHome
    {
        public string NameSurname { get; set; }
        public string IdentityNo { get; set; }
        public DateTime Birthdate { get; set; }
        public bool IsConfirm { get; set; }

        public int GenderId { get; set; }
        public int DepartmanId { get; set; }
        public int? PatientInformationId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Departman Departman { get; set; }
        public virtual PatientInformation PatientInformation { get; set; }

        public ICollection<PatientRoom> PatientRooms { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

        public Patient()
        {
            IsConfirm = false;
        }
    }
}
