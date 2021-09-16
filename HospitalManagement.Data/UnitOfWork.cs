using HospitalManagement.Data.Interfaces;
using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly HospitalManagementDbContext context;
        public IUserRepository Users { get; }
        public IPatientRepository Patients { get; }
        public IRelationRepository Relations { get; }

        public UnitOfWork(HospitalManagementDbContext dbContext,
            IUserRepository users,
            IPatientRepository patients,
            IRelationRepository relations)
        {
            this.context = dbContext;
            this.Users = users;
            this.Patients = patients;
            this.Relations = relations;
        }

        public void Save()
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    dbContextTransaction.Rollback();
                }
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
