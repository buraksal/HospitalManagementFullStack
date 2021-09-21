using HospitalManagement.Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Business.Interfaces
{
    public interface IErrorService
    {
        void Insert(ErrorDto error);
        ErrorDto CreateError(string UserId, string errorMessage);

    }
}
