using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Entities.Models
{
    public class Floor:BaseHome
    {
        public string FloorNumber { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
