using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Entities.Models
{
    public class PatientRoom:BaseHome
    {
        public string FloorNumber { get; set; }
        public string RoomNumber { get; set; }

        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
