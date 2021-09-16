using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Data.Interfaces
{
    public interface IRelationRepository : IGenericRepository<UserPatientRelation>
    {
    }
}
