using HospitalManagement.Data;
using HospitalManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Test
{

    [TestClass]
    public class UserTest
    {
        protected DbContextOptions<HospitalManagementDbContext> ContextOptions { get; }

        public UserTest(DbContextOptions<HospitalManagementDbContext> contextOptions)
        {
            ContextOptions = contextOptions;
            Seed();
        }

        private void Seed()
        {
            using (var context = new HospitalManagementDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                User user1 = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Burak SAL",
                    Password = "123456",
                    Email = "buraks@gmail.com",
                    Ssn = "123456780",
                    UserType = UserTypes.Doctor
                };
                User user2 = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Ali Ayse",
                    Password = "123456789",
                    Email = "alia@gmail.com",
                    Ssn = "789456120",
                    UserType = UserTypes.Doctor
                };
                User user3 = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Fatma Yıldırım",
                    Password = "fatmaq",
                    Email = "fatmay@gmail.com",
                    Ssn = "456123780",
                    UserType = UserTypes.Doctor
                };
                User user4 = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Fatma Yıldırım",
                    Password = "fatmaq",
                    Email = "fatmayldrm@gmail.com",
                    Ssn = "789123465",
                    UserType = UserTypes.Nurse
                };
                User user5 = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Hikmet Toplayan",
                    Password = "hikot",
                    Email = "hikmett@gmail.com",
                    Ssn = "147852369",
                    UserType = UserTypes.Nurse
                };
                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Users.Add(user3);
                context.Users.Add(user4);
                context.Users.Add(user5);

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void GetUsers()
        {
            using (var context = new HospitalManagementDbContext(ContextOptions))
            {
                List<User> users = context.Users.ToList();
                User userToTest = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Hikmet Toplayan",
                    Password = "hikot",
                    Email = "hikmett@gmail.com",
                    Ssn = "147852369",
                    UserType = UserTypes.Nurse
                };
                Assert.Equals(5, users.Count);
                Assert.IsFalse(users.Contains(userToTest));
            }
        }

        [TestMethod]
        public void AddUser()
        {
            using (var context = new HospitalManagementDbContext(ContextOptions))
            {
                User userToAdd = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Hikmet Toplayan",
                    Password = "hikot",
                    Email = "hikmett@gmail.com",
                    Ssn = "741258369",
                    UserType = UserTypes.Nurse
                };
                context.Users.Add(userToAdd);
                List<User> users = context.Users.ToList();
                Assert.Equals(6, users.Count);
            }

        }

        [TestMethod]
        public void DeleteUser()
        {
            using (var context = new HospitalManagementDbContext(ContextOptions))
            {
                List<User> users = context.Users.ToList();
                context.Users.Remove(users[0]);
                users = context.Users.ToList();
                Assert.Equals(5, users.Count);
            }

        }
    }
}
