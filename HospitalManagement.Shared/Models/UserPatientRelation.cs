using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Shared.Models
{
    public class UserPatientRelation
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Patient Patient { get; set; }
    }
}
