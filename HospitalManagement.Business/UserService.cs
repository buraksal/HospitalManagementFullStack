using HospitalManagement.Data;
using HospitalManagement.Service.DTO;
using HospitalManagement.Shared.Models;
using HospitalManagent.Infrastructure;
using System;
using System.Linq;

namespace HospitalManagement.Business
{
    public class UserService : IUserService, IDisposable
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IContainer container;

        public UserService(IUnitOfWork unitOfWork, IContainer container)
        {
            this.unitOfWork = unitOfWork;
            this.container = container;
        }

        public IQueryable<User> GetAll()
        {
            var result = this.container.Repository<User>().Get(orderBy: q => q.OrderBy(d => d.Id)).AsQueryable();
            return result;
        }

        public User Find(int? id)
        {
            return this.container.Repository<User>().GetByID(id);
        }

        public void Insert(User user)
        {
            this.container.Repository<User>().Insert(user);
            unitOfWork.Save();
        }

        public void Update(User user)
        {
            this.container.Repository<User>().Update(user);
            unitOfWork.Save();
        }

        public void Delete(int? id)
        {
            User user = this.container.Repository<User>().GetByID(id);
            this.container.Repository<User>().Delete(user);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public User LogInControl(LoginDto logInRequest)
        {
            User user = this.container.Repository<User>().Get(u => u.Email.Equals(logInRequest.Email) && u.Password.Equals(logInRequest.Password)).First();
            if (user == null)
                return null;
            else
                return user;
        }

        public bool SignUp(SignupDto signUpRequest)
        {
            var user = this.container.Repository<User>().Get(l => l.Ssn == signUpRequest.Ssn).FirstOrDefault();
            if (user != null)
            {
                return false;
            }

            this.container.Repository<User>().Insert(CreateUser(signUpRequest));
            unitOfWork.Save();
            return true;
        }

        public User CreateUser(SignupDto signUpRequest)
        {
            User newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = signUpRequest.Name,
                Email = signUpRequest.Email,
                Password = signUpRequest.Password,
                Ssn = signUpRequest.Ssn,
                UserType = signUpRequest.UserType
            };
            return newUser;
        }
    }
}