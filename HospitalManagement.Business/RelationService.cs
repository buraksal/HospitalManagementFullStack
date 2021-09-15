using HospitalManagement.Data;
using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Business
{
    public class RelationService : IDisposable
    {
        private UnitOfWork unitOfWork;

        public RelationService()
        {
            unitOfWork = new UnitOfWork();
        }

        public IQueryable<UserPatientRelation> GetAll()
        {
            return unitOfWork.RelationRepository.Get(orderBy: q => q.OrderBy(d => d.RelationId)).AsQueryable();
        }

        public UserPatientRelation Find(int? id)
        {
            return unitOfWork.RelationRepository.GetByID(id);
        }

        public void Insert(UserPatientRelation relation)
        {
            unitOfWork.RelationRepository.Insert(relation);
            unitOfWork.Save();
        }

        public void Update(UserPatientRelation relation)
        {
            unitOfWork.RelationRepository.Update(relation);
            unitOfWork.Save();
        }

        public void Delete(int? id)
        {
            UserPatientRelation relation = unitOfWork.RelationRepository.GetByID(id);
            unitOfWork.RelationRepository.Delete(relation);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

    }
}
