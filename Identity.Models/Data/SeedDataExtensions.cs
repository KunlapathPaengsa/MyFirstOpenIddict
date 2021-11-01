//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace Identity.Models.Data
//{
//    public static class SeedDataExtensions
//    {
//        public static ModelBuilder DefaultSystemUserData(this ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<User>().HasData(new User
//            {
//                Id = Guid.Parse("12E087F2-F1D6-4EDD-8FA3-BA379FC65F61"),
//                UserName = "sysmoneytree",
//                Password = "8V6YYibZxixxMxovOjgSL0hEz0IWh/8EpiNBsCI5i2K6daf6wAXSmNmIMpHy/ZBiacdHFR7BOqF8IIwUlS/isg==",
//                Email = "moneytree@buzzebees.com",
//                SecurityStamp = "c3lzbW9uZXl0cmVlfGUyZmIzM2E5LTRmYzItNDg1ZS1iMmEzLTQ4MjhjOTM4ZGNmN3w2Mzc0NDE0MzM5NTI3MjQ3MDk",
//                LastUpdatedPwd = new DateTime(2022, 03, 20, 0, 0, 0),
//                PwdExpiredDays = 90,
//                PhoneNumber = "1123456789",
//                AccessFailedCount = 0,
//                IsLocked = false,
//                IsActive = true,
//                LastLoginDate = new DateTime(2021, 03, 20, 0, 0, 0),
//                CreatedDate = new DateTime(2021, 03, 20, 0, 0, 0),
//                UpdatedDate = new DateTime(2021, 03, 20, 0, 0, 0),
//                CreatedBy = DefaultAuditable.SystemAuditable,
//                UpdatedBy = DefaultAuditable.SystemAuditable
//            });

//            return modelBuilder;
//        }

//        public static ModelBuilder DefaultSystemRoleData(this ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Role>().HasData(
//                new Role
//                {
//                    Id = Guid.Parse("9589BDD2-0953-4DFB-B5BA-0AACBA2E3C0C"),
//                    Name = "administrator",
//                    Description = "Administrator",
//                    IsActive = true,
//                    CreatedDate = new DateTime(2021, 08, 11, 0, 0, 0),
//                    UpdatedDate = new DateTime(2021, 08, 11, 0, 0, 0),
//                    CreatedBy = DefaultAuditable.SystemAuditable,
//                    UpdatedBy = DefaultAuditable.SystemAuditable
//                },
//                new Role
//                {
//                    Id = Guid.Parse("F083973C-687B-4675-BEF0-6920C0A6A228"),
//                    Name = "qc",
//                    Description = "QC",
//                    IsActive = true,
//                    CreatedDate = new DateTime(2021, 08, 11, 0, 0, 0),
//                    UpdatedDate = new DateTime(2021, 08, 11, 0, 0, 0),
//                    CreatedBy = DefaultAuditable.SystemAuditable,
//                    UpdatedBy = DefaultAuditable.SystemAuditable
//                },
//                new Role
//                {
//                    Id = Guid.Parse("CFA24DF4-47F9-4595-897A-12D1140D595F"),
//                    Name = "supervisor",
//                    Description = "Supervisor",
//                    IsActive = true,
//                    CreatedDate = new DateTime(2021, 08, 11, 0, 0, 0),
//                    UpdatedDate = new DateTime(2021, 08, 11, 0, 0, 0),
//                    CreatedBy = DefaultAuditable.SystemAuditable,
//                    UpdatedBy = DefaultAuditable.SystemAuditable
//                },
//                new Role
//                {
//                    Id = Guid.Parse("3E263118-D0FD-42C4-9B64-CA990F218A8B"),
//                    Name = "staff",
//                    Description = "Staff",
//                    IsActive = true,
//                    CreatedDate = new DateTime(2021, 08, 11, 0, 0, 0),
//                    UpdatedDate = new DateTime(2021, 08, 11, 0, 0, 0),
//                    CreatedBy = DefaultAuditable.SystemAuditable,
//                    UpdatedBy = DefaultAuditable.SystemAuditable
//                }
//            );

//            return modelBuilder;
//        }

//    }
//}
