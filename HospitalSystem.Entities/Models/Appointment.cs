using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Entities.Models
{
    public class Appointment:BaseHome
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public bool IsConfirm { get; set; }

        public int? DoctorId { get; set; }
        public int? DepartmanId { get; set; }
        public int? PatientId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Departman Departman { get; set; }
        public virtual Patient Patient { get; set; }

        public Appointment()
        {
            IsConfirm = false;
        }
    }
}
