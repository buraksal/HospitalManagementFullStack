using HospitalManagement.Data.Interfaces;
using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Data
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {

        public PatientRepository(HospitalManagementDbContext context): base(context)
        {

        }

    }
}
