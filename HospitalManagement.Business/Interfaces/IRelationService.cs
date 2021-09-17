using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Business.Interfaces
{
    public interface IRelationService
    {
        IQueryable<UserPatientRelation> GetAll();
        UserPatientRelation Find(string patientName);
        void Insert(UserPatientRelation relation);
        void Update(UserPatientRelation relation);
        void Delete(UserPatientRelation relation);
        void Dispose();
    }
}
