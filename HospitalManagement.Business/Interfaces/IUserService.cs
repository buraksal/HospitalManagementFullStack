using HospitalManagement.Service.DTO;
using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Business
{
    public interface IUserService
    {
        IQueryable<User> GetAll();
        User Find(int? id);
        void Insert(User user);
        void Update(User user);
        void Delete(int? id);
        void Dispose();
        bool LogInControl(LoginDto logInRequest);
        bool SignUp(SignupDto signUpRequest);

    }
}
