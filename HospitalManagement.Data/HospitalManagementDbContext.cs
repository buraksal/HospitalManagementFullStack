using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace HospitalManagement.Data
{
    public class HospitalManagementDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<UserPatientRelation> UserPatientRelations { get; set; }

    }
}
