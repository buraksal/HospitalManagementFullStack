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
        User Find(string ssn);
        void Insert(User user);
        void Update(User user);
        void Delete(int? id);
        void Dispose();
        string LogInControl(LoginDto logInRequest);
        bool SignUp(SignupDto signUpRequest);

    }
}
