using HospitalManagement.Data.Interfaces;
using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Data
{
    public class RelationRepository: GenericRepository<UserPatientRelation>, IRelationRepository
    {
        public RelationRepository(HospitalManagementDbContext context): base(context)
        {
        }

        
    }
}
