using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePatients.Models
{
    public class Patient
    {
        public long AutoId { get; set; }
        public string PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public short Gender { get; set; }
        public string ScanName { get; set; }
        public string ReferralDrName { get; set; }
      
    }

}
