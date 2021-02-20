using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Entities.Models
{
    public class Employee:BaseHome
    {
        public string NameSurname { get; set; }
        public string IdentityNo { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Hiredate { get; set; }
        public string Photo { get; set; }
        public bool IsConfirm { get; set; }

        public int GenderId { get; set; }
        public int TitleId { get; set; }
        public int EmployeeInformationId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Title Title { get; set; }
        public virtual EmployeeInformation EmployeeInformation { get; set; }

        public Employee()
        {
            IsConfirm = false;
        }
    }
}
