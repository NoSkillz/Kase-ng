namespace Kase_ng.Migrations
{
    using DataAccess;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KaseDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        // TODO maybe change string to enum
        protected override void Seed(KaseDbContext context)
        {
            context.TestCaseStatuses.AddOrUpdate(
                p => p.Id,
                new TestCaseStatus
                {
                    Id = 1,
                    Name = "Pass"
                },
                new TestCaseStatus
                {
                    Id = 2,
                    Name = "Fail"
                },
                new TestCaseStatus
                {
                    Id = 3,
                    Name = "Not tested"
                },
                new TestCaseStatus
                {
                    Id = 4,
                    Name = "Blocked"
                });
            context.SaveChanges();

            context.TestCases.AddOrUpdate(
                p => p.Id,
                new TestCase
                {
                    Id = 1,
                    Name = "Test cases can be created",
                    Description = "Test to run to ensure that cases can be created in the application",
                    LastRun = DateTime.Now,
                    TestCaseStatus = context.TestCaseStatuses.Where(t => t.Name == "Pass").First()
                },
                new TestCase
                {
                    Id = 2,
                    Name = "Can create tasks",
                    Description = "Creation of tasks. This should be run weekly",
                    LastRun = DateTime.Now,
                    TestCaseStatus = context.TestCaseStatuses.Where(t => t.Name == "Fail").First()
                });

            context.SaveChanges();
        }
    }
}
