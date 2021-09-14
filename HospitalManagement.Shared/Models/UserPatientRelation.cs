using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Shared.Models
{
    public class UserPatientRelation
    {
        [Key]
        public Guid RelationId { get; set; }
        public string UserId { get; set; }
        public string PatientId { get; set; }
        public string Complaint { get; set; }

    }
}
