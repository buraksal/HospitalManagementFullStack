using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Data.DTO.Interfaces
{
    public interface IPaginationDto
    {
        public int PageNumber { get; set; }
        public int TakeLimit { get; set; }
    }
}
