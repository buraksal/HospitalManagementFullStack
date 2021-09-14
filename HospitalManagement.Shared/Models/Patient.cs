using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Shared.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Ssn { get; set; }
        public string Complaint { get; set; }
        public string CreatedBy { get; set; }

    }
}
