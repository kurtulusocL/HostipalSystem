using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Entities.Models
{
    public class Nurse:BaseHome
    {
        public string NameSurname { get; set; }
        public string IdentityNo { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Hiredate { get; set; }
        public string Photo { get; set; }
        public bool IsConfirm { get; set; }

        public int GenderId { get; set; }
        public int DepartmanId { get; set; }
        public int NurseInformationId { get; set; }
        public int NurseDegreeId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Departman Departman { get; set; }
        public virtual NurseDegree NurseDegree { get; set; }
        public virtual NurseInformation NurseInformation { get; set; }

        public Nurse()
        {
            IsConfirm = false;
        }
    }
}
