using HospitalManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagent.Infrastructure
{
    public interface IContainer
    {
        IGenericRepository<T> Repository<T>() where T : class;
    }
}
