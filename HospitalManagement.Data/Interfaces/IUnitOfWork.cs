using HospitalManagement.Data.Interfaces;
using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Data
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IPatientRepository Patients { get; }
        IRelationRepository Relations { get; }
        void Save();
        void Dispose();
    }
}
