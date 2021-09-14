using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Data
{
    public class UnitOfWork : IDisposable
    {
        private HospitalManagementDbContext context = new HospitalManagementDbContext();
        private GenericRepository<User> userRepo;
        private GenericRepository<Patient> patientRepo;
        private GenericRepository<UserPatientRelation> relationRepo;
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepo == null)
                {
                    this.userRepo = new GenericRepository<User>(context);
                }
                return userRepo;
            }
        }

        public GenericRepository<Patient> PatientRepository
        {
            get
            {
                if (this.patientRepo == null)
                {
                    this.patientRepo = new GenericRepository<Patient>(context);
                }
                return patientRepo;
            }
        }

        public GenericRepository<UserPatientRelation> RelationRepository
        {
            get
            {
                if (this.relationRepo == null)
                {
                    this.relationRepo = new GenericRepository<UserPatientRelation>(context);
                }
                return relationRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
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
