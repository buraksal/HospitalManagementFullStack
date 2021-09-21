using HospitalManagement.Data.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Data.DTO
{
    public class ErrorDto : IErrorDto
    {
        public Guid Id { get; set; }
        public DateTime IssueDate { get; set; }
        public string UserId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
