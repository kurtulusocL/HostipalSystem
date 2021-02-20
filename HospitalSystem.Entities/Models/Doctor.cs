using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Entities.Models
{
    public class Doctor:BaseHome
    {
        public string NameSurname { get; set; }
        public string IdentityNo { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Hiredate { get; set; }
        public string Photo { get; set; }
        public bool IsConfirm { get; set; }

        public int GenderId { get; set; }
        public int TitleId { get; set; }
        public int DepartmanId { get; set; }
        public int DoctorInformationId { get; set; }
        public int DoctorDegreeId { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Title Title { get; set; }
        public virtual Departman Departman { get; set; }
        public virtual DoctorInformation DoctorInformation { get; set; }
        public virtual DoctorDegree DoctorDegree { get; set; }
        public virtual Floor Floor { get; set; }
        public virtual Room Room { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public Doctor()
        {
            IsConfirm = false;
        }
    }
}
