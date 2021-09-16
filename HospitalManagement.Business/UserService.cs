using HospitalManagement.Data;
using HospitalManagement.Service.DTO;
using HospitalManagement.Shared.Models;
using System;
using System.Linq;

namespace HospitalManagement.Business
{
    public class UserService: IUserService,IDisposable
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<User> GetAll()
        {
            return unitOfWork.Users.Get(orderBy: q => q.OrderBy(d => d.Id)).AsQueryable();
        }

        public User Find(int? id)
        {

            return unitOfWork.Users.GetByID(id);
        }

        public void Insert(User user)
        {

            unitOfWork.Users.Insert(user);
            unitOfWork.Save();
        }

        public void Update(User user)
        {
            unitOfWork.Users.Update(user);
            unitOfWork.Save();
        }

        public void Delete(int? id)
        {
            User user = unitOfWork.Users.GetByID(id);
            unitOfWork.Users.Delete(user);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public bool LogInControl(LoginDto logInRequest)
        {
            var user = unitOfWork.Users.Get().Where(u => u.Email.Equals(logInRequest.Email) && u.Password.Equals(logInRequest.Password));
            if(user == null)
            {
                return false;
            } else
            {
                return true;
            }
        }
        public bool SignUp(SignupDto signUpRequest)
        {
            var user = unitOfWork.Users.Get().Where(u => u.Ssn.Equals(signUpRequest.Ssn));
            if (user == null)
            {
                return false;
            }
            else
            {
                unitOfWork.Users.Insert(CreateUser(signUpRequest));
                unitOfWork.Save();
                return true;
            }
        }

        public User CreateUser(SignupDto signUpRequest)
        {
            User newUser = new User();
            newUser.Id = Guid.NewGuid();
            newUser.Name = signUpRequest.Name;
            newUser.Email = signUpRequest.Email;
            newUser.Password = signUpRequest.Password;
            newUser.Ssn = signUpRequest.Ssn;
            newUser.UserType = signUpRequest.UserType;
            return newUser;
        }

    }
}