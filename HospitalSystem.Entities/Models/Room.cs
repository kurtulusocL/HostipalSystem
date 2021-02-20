using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Entities.Models
{
    public class Room:BaseHome
    {
        public string RoomNumber { get; set; }

        public int? FloorId { get; set; }
        public virtual Floor Floor { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
