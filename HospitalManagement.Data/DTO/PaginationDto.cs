using HospitalManagement.Data.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Data.DTO
{
    public class PaginationDto : IPaginationDto
    {
        public int PageNumber { get; set; }
        public int TakeLimit { get; set; }
    }
}
