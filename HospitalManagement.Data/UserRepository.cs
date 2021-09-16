using HospitalManagement.Data.Interfaces;
using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HospitalManagement.Data
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(HospitalManagementDbContext context): base(context)
        {
        }


    }
}
