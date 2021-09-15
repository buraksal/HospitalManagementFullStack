using HospitalManagement.Data;
using HospitalManagement.Shared.Models;
using System;
using System.Linq;

namespace HospitalManagement.Business
{
    public class UserService: IDisposable
    {
        private UnitOfWork unitOfWork;

        public UserService()
        {
            unitOfWork = new UnitOfWork();
        }

        public IQueryable<User> GetAll()
        {
            return unitOfWork.UserRepository.Get(orderBy: q => q.OrderBy(d => d.Id)).AsQueryable();
        }

        public User Find(int? id)
        {
            return unitOfWork.UserRepository.GetByID(id);
        }

        public void Insert(User user)
        {
            unitOfWork.UserRepository.Insert(user);
            unitOfWork.Save();
        }

        public void Update(User user)
        {
            unitOfWork.UserRepository.Update(user);
            unitOfWork.Save();
        }

        public void Delete(int? id)
        {
            User user = unitOfWork.UserRepository.GetByID(id);
            unitOfWork.UserRepository.Delete(user);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

    }
}