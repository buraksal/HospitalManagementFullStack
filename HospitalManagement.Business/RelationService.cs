using HospitalManagement.Business.Interfaces;
using HospitalManagement.Data;
using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Business
{
    public class RelationService : IRelationService, IDisposable
    {
        private readonly IUnitOfWork unitOfWork;

        public RelationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<UserPatientRelation> GetAll()
        {
            return unitOfWork.Relations.Get(orderBy: q => q.OrderBy(d => d.RelationId)).AsQueryable();
        }

        public UserPatientRelation Find(int? id)
        {
            return unitOfWork.Relations.GetByID(id);
        }

        public void Insert(UserPatientRelation relation)
        {
            unitOfWork.Relations.Insert(relation);
            unitOfWork.Save();
        }

        public void Update(UserPatientRelation relation)
        {
            unitOfWork.Relations.Update(relation);
            unitOfWork.Save();
        }

        public void Delete(int? id)
        {
            UserPatientRelation relation = unitOfWork.Relations.GetByID(id);
            unitOfWork.Relations.Delete(relation);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

    }
}
