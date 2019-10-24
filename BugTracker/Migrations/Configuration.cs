namespace BugTracker.Migrations
{
    using BugTracker.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<BugTracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BugTracker.Models.ApplicationDbContext context)
        {
            #region Role Creation
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                roleManager.Create(new IdentityRole { Name = "Administrator" });
            }
            if (!context.Roles.Any(r => r.Name == "Project Manager"))
            {
                roleManager.Create(new IdentityRole { Name = "Project Manager" });
            }
            if (!context.Roles.Any(r => r.Name == "Developer"))
            {
                roleManager.Create(new IdentityRole { Name = "Developer" });
            }
            if (!context.Roles.Any(r => r.Name == "Submitter"))
            {
                roleManager.Create(new IdentityRole { Name = "Submitter" });
            }
            #endregion
            #region User Creation
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "DemoAdmin@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoAdmin@mailinator.com",
                    Email = "DemoAdmin@mailinator.com",
                    FirstName = "Janice",
                    LastName = "Doe",
                    DisplayName = "J. Doe",
                }, "Abc123!");
            }
            if (!context.Users.Any(u => u.Email == "DemoPM@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoPM@mailinator.com",
                    Email = "DemoPM@mailinator.com",
                    FirstName = "Jonathan",
                    LastName = "Public",
                    DisplayName = "J.Q. Public",
                }, "Abc123!");
            }
            if (!context.Users.Any(u => u.Email == "DemoDev@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoDev@mailinator.com",
                    Email = "DemoDev@mailinator.com",
                    FirstName = "Sally",
                    LastName = "McBride",
                    DisplayName = "S. McBride",
                }, "Abc123!");
            }
            if (!context.Users.Any(u => u.Email == "DemoSub@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoSub@mailinator.com",
                    Email = "DemoSub@mailinator.com",
                    FirstName = "Nikola",
                    LastName = "Tesla",
                    DisplayName = "N. Tesla",
                }, "Abc123!");
            }
            #endregion
            #region Role Assignment
            var adminId = userManager.FindByEmail("DemoAdmin@mailinator.com").Id;
            userManager.AddToRole(adminId, "Administrator");

            var projId = userManager.FindByEmail("DemoPM@mailinator.com").Id;
            userManager.AddToRole(projId, "Project Manager");

            var devId = userManager.FindByEmail("DemoDev@mailinator.com").Id;
            userManager.AddToRole(devId, "Developer");

            var subId = userManager.FindByEmail("DemoSub@mailinator.com").Id;
            userManager.AddToRole(subId, "Submitter");
            #endregion
            #region Project Seed
            if (!context.Projects.Any(p => p.Id == 1))
            {
                new Project()
                {
                    Id = 1,
                    Name = "First Demo",
                    Description = "The first demo project seed",
                };
            }
            if (!context.Projects.Any(p => p.Id == 2))
            {
                new Project()
                {
                    Id = 2,
                    Name = "Second Demo",
                    Description = "The second demo project seed",
                };
            }
            if (!context.Projects.Any(p => p.Id == 3))
            {
                new Project()
                {
                    Id = 3,
                    Name = "Third Demo",
                    Description = "The third demo project seed",
                };
            }
            if (!context.Projects.Any(p => p.Id == 4))
            {
                new Project()
                {
                    Id = 4,
                    Name = "Fourth Demo",
                    Description = "The fourth demo project seed",
                };
            }
            #endregion
            #region Ticket Status Seed
            if (!context.TicketStatus.Any(s => s.Id == 1))
            {
                new TicketStatus()
                {
                    Id = 1,
                    Name = "Created",
                    Description = "This ticket has been created, but has not been assigned",
                    //Description could include reference to creator, then assigned dev, then PM that resolves
                };
            }
            if (!context.TicketStatus.Any(s => s.Id == 2))
            {
                new TicketStatus()
                {
                    Id = 2,
                    Name = "Assigned",
                    Description = "This ticket has been created and assigned",
                };
            }
            if (!context.TicketStatus.Any(s => s.Id == 3))
            {
                new TicketStatus()
                {
                    Id = 3,
                    Name = "Resolved",
                    Description = "This ticket has been resolved",
                };
            }
            #endregion
            #region Ticket Priority Seed
            if (!context.TicketPriorities.Any(p => p.Id == 1))
            {
                new TicketPriority()
                {
                    Id = 1,
                    Name = "Low",
                    Description = "This ticket is low priority",
                };
            }
            if (!context.TicketPriorities.Any(p => p.Id == 2))
            {
                new TicketPriority()
                {
                    Id = 2,
                    Name = "Medium",
                    Description = "This ticket is medium priority",
                };
            }
            if (!context.TicketPriorities.Any(p => p.Id == 3))
            {
                new TicketPriority()
                {
                    Id = 3,
                    Name = "High",
                    Description = "This ticket is high priority",
                };
            }
            #endregion
            #region Ticket Type Seed
            if (!context.TicketTypes.Any(t => t.Id == 1))
            {
                new TicketType()
                {
                    Id = 1,
                    Name = "Software",
                    Description = "Software Ticket",
                };
            }
            if (!context.TicketTypes.Any(t => t.Id == 2))
            {
                new TicketType()
                {
                    Id = 2,
                    Name = "Hardware",
                    Description = "Hardware Ticket",
                };
            }
            if (!context.TicketTypes.Any(t => t.Id == 3))
            {
                new TicketType()
                {
                    Id = 3,
                    Name = "UI",
                    Description = "UI Ticket",
                };
            }
            if (!context.TicketTypes.Any(t => t.Id == 4))
            {
                new TicketType()
                {
                    Id = 4,
                    Name = "Other",
                    Description = "Other Issue Ticket",
                };
            }
            #endregion
        }
    }
}