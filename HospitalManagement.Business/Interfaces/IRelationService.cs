﻿using HospitalManagement.Service.DTO;
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
        void Insert(PatientDto patient);
        void Update(PatientDto patient);
        void Delete(PatientDto patient);
        void Dispose();
    }
}
