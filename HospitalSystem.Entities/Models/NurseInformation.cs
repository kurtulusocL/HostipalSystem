﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Entities.Models
{
    public class NurseInformation:BaseHome
    {
        public string Province { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeNumber { get; set; }

        public ICollection<Nurse> Nurses { get; set; }
    }
}
