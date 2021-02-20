using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Entities.Models
{
    public class Title:BaseHome
    {
        public string Name { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
