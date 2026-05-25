using System;
using System.Collections.Generic;
using System.Linq;
using sealHkthon.Entities.ThuanVCT.Models;
using sealHkthon.Repositories.ThuanVCT.DBContext;

namespace sealHkthon.WebMVCApp.ThuanVCT.Models
{
    public static class DbInitializer
    {
        public static void Seed(PRN222_HACKATHONContext context)
        {
            // Ensure database exists
            context.Database.EnsureCreated();

            // 1. Seed SystemUserAccount
            if (!context.SystemUserAccounts.Any())
            {
                var users = new List<SystemUserAccount>
                {
                    new SystemUserAccount
                    {
                        UserName = "admin",
                        Password = "password123", // Keep simple for testing
                        FullName = "System Administrator",
                        Email = "admin@sealhkthon.com",
                        Phone = "0901234567",
                        EmployeeCode = "EMP001",
                        RoleId = 1, // Admin
                        RequestCode = "REQ001",
                        CreatedDate = DateTime.Now,
                        ApplicationCode = "SEAL",
                        CreatedBy = "DbInitializer",
                        IsActive = true
                    },
                    new SystemUserAccount
                    {
                        UserName = "judge1",
                        Password = "password123",
                        FullName = "Dr. Johnathan Smith",
                        Email = "john.smith@sealhkthon.com",
                        Phone = "0908887777",
                        EmployeeCode = "EMP002",
                        RoleId = 2, // Judge / Juror
                        RequestCode = "REQ002",
                        CreatedDate = DateTime.Now.AddDays(-2),
                        ApplicationCode = "SEAL",
                        CreatedBy = "DbInitializer",
                        IsActive = true
                    },
                    new SystemUserAccount
                    {
                        UserName = "judge2",
                        Password = "password123",
                        FullName = "Prof. Alice Vance",
                        Email = "alice.vance@sealhkthon.com",
                        Phone = "0906665555",
                        EmployeeCode = "EMP003",
                        RoleId = 2, // Judge / Juror
                        RequestCode = "REQ003",
                        CreatedDate = DateTime.Now.AddDays(-2),
                        ApplicationCode = "SEAL",
                        CreatedBy = "DbInitializer",
                        IsActive = true
                    },
                    new SystemUserAccount
                    {
                        UserName = "dev_alex",
                        Password = "password123",
                        FullName = "Alex Mercer",
                        Email = "alex.mercer@sealhkthon.com",
                        Phone = "0987654321",
                        EmployeeCode = "EMP004",
                        RoleId = 3, // Participant
                        RequestCode = "REQ004",
                        CreatedDate = DateTime.Now.AddDays(-5),
                        ApplicationCode = "SEAL",
                        CreatedBy = "DbInitializer",
                        IsActive = true
                    },
                    new SystemUserAccount
                    {
                        UserName = "dev_lewis",
                        Password = "password123",
                        FullName = "Lewis Hamilton",
                        Email = "lewis.h@sealhkthon.com",
                        Phone = "0989999999",
                        EmployeeCode = "EMP005",
                        RoleId = 3, // Participant
                        RequestCode = "REQ005",
                        CreatedDate = DateTime.Now.AddDays(-4),
                        ApplicationCode = "SEAL",
                        CreatedBy = "DbInitializer",
                        IsActive = true
                    }
                };

                context.SystemUserAccounts.AddRange(users);
                context.SaveChanges();
            }

            // 2. Seed Events and Rounds
            if (!context.EventsThuanVcts.Any())
            {
                // Event 1: FPT University Coding Arena
                var event1 = new EventsThuanVct
                {
                    EventName = "FPT University Coding Arena SU26",
                    Description = "The ultimate competitive programming and system architecture challenge for FPT engineering students.",
                    Status = 1,
                    PublishDate = DateTime.Now.AddDays(-10),
                    IsActive = true
                };

                // Event 2: Generative AI Innovation Hackathon
                var event2 = new EventsThuanVct
                {
                    EventName = "Generative AI Innovation Hackathon",
                    Description = "Design, build and prototype intelligent features utilizing state-of-the-art LLMs and diffusion models.",
                    Status = 1,
                    PublishDate = DateTime.Now.AddDays(-5),
                    IsActive = true
                };

                // Event 3: IoT Smart Green Cities
                var event3 = new EventsThuanVct
                {
                    EventName = "IoT Smart & Green Cities Tournament",
                    Description = "Develop microgrid management solutions and sensory grids to enable efficient environmental tracking in modern cities.",
                    Status = 0, // Upcoming Draft
                    PublishDate = DateTime.Now.AddDays(5),
                    IsActive = true
                };

                context.EventsThuanVcts.AddRange(event1, event2, event3);
                context.SaveChanges(); // Persist to get Identity IDs

                // Seed Rounds
                if (!context.RoundsThuanVcts.Any())
                {
                    var rounds = new List<RoundsThuanVct>
                    {
                        // Rounds for Event 1 (Coding Arena)
                        new RoundsThuanVct
                        {
                            EventThuanVctid = event1.EventThuanVctid,
                            RoundName = "Qualifying Ideation Round",
                            Deadline = DateTime.Now.AddDays(-4),
                            PromotionRule = 15, // Top 15 teams advance
                            SortOrder = 1,
                            Price = 0
                        },
                        new RoundsThuanVct
                        {
                            EventThuanVctid = event1.EventThuanVctid,
                            RoundName = "Live 24-Hour Code Sprint",
                            Deadline = DateTime.Now.AddDays(2),
                            PromotionRule = 5, // Top 5 teams advance
                            SortOrder = 2,
                            Price = 150000
                        },
                        new RoundsThuanVct
                        {
                            EventThuanVctid = event1.EventThuanVctid,
                            RoundName = "Grand Pitch & Jury Review",
                            Deadline = DateTime.Now.AddDays(5),
                            PromotionRule = 1, // Winner
                            SortOrder = 3,
                            Price = 250000
                        },

                        // Rounds for Event 2 (AI Hackathon)
                        new RoundsThuanVct
                        {
                            EventThuanVctid = event2.EventThuanVctid,
                            RoundName = "Dataset & Fine-Tuning Stage",
                            Deadline = DateTime.Now.AddDays(3),
                            PromotionRule = 8,
                            SortOrder = 1,
                            Price = 50000
                        },
                        new RoundsThuanVct
                        {
                            EventThuanVctid = event2.EventThuanVctid,
                            RoundName = "Working System Showcase",
                            Deadline = DateTime.Now.AddDays(7),
                            PromotionRule = 1,
                            SortOrder = 2,
                            Price = 120000
                        },

                        // Rounds for Event 3 (IoT Green Cities)
                        new RoundsThuanVct
                        {
                            EventThuanVctid = event3.EventThuanVctid,
                            RoundName = "Hardware Prototype Blueprint",
                            Deadline = DateTime.Now.AddDays(15),
                            PromotionRule = 10,
                            SortOrder = 1,
                            Price = 0
                        }
                    };

                    context.RoundsThuanVcts.AddRange(rounds);
                    context.SaveChanges();
                }
            }
        }
    }
}
