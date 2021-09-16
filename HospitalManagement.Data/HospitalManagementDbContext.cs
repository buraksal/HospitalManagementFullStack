using HospitalManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Text;

namespace HospitalManagement.Data
{
    public class HospitalManagementDbContext : DbContext
    {
        public HospitalManagementDbContext(DbContextOptions<HospitalManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<UserPatientRelation> UserPatientRelations { get; set; }

    }
}
