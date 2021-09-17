using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Shared.Models
{
    public class UserPatientRelation
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PatientName { get; set; }
        public string Complaint { get; set; }

    }
}
