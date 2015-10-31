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
            context.ItemStatuses.AddOrUpdate(
                p => p.Id,
                new ItemStatus
                {
                    Id = 1,
                    Name = "Pass"
                },
                new ItemStatus
                {
                    Id = 2,
                    Name = "Fail"
                },
                new ItemStatus
                {
                    Id = 3,
                    Name = "Not run"
                },
                new ItemStatus
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
                    ItemStatus = context.ItemStatuses.Where(t => t.Name == "Pass").First()
                },
                new TestCase
                {
                    Id = 2,
                    Name = "Can edit test cases",
                    Description = "Editing of test cases.",
                    LastRun = DateTime.Now,
                    ItemStatus = context.ItemStatuses.Where(t => t.Name == "Fail").First()
                },
                new TestCase
                {
                    Id = 3,
                    Name = "Can apply classes",
                    Description = "Test if classes can be applied",
                    LastRun = DateTime.Now,
                    ItemStatus = context.ItemStatuses.Where(t => t.Name == "Blocked").First()
                },
                new TestCase
                {
                    Id = 4,
                    Name = "Can change task status",
                    Description = "Test if statuses can be changed",
                    LastRun = DateTime.Now,
                    ItemStatus = context.ItemStatuses.Where(t => t.Name == "Not run").First()
                },
                new TestCase
                {
                    Id = 5,
                    Name = "Can add test cases",
                    Description = "Test for adding test cases",
                    LastRun = DateTime.Now,
                    ItemStatus = context.ItemStatuses.Where(t => t.Name == "Not run").First()
                },
                new TestCase
                {
                    Id = 6,
                    Name = "Test cases with long names look nice in the page. We should test this out. See how it looks. It this enough?",
                    Description = "I needed this",
                    LastRun = DateTime.Now,
                    ItemStatus = context.ItemStatuses.Where(t => t.Name == "Pass").First()
                });
            context.SaveChanges();

            context.Steps.AddOrUpdate(
                p => p.Id,
                // Steps for first test case
                new Step
                {
                    Id = 1,
                    Name = "Can go to page",
                    ItemStatus = context.ItemStatuses.Where(t => t.Name == "Pass").First(),
                    TestCase = context.TestCases.Where(t => t.Id == 1).First()
                },
                new Step
                {
                    Id = 2,
                    Name = "Clicking on the add button allows a way to input a test case name",
                    ItemStatus = context.ItemStatuses.Where(t => t.Name == "Pass").First(),
                    TestCase = context.TestCases.Where(t => t.Id == 1).First()
                },
                new Step
                {
                    Id = 3,
                    Name = "Test case name cannot be empty",
                    ItemStatus = context.ItemStatuses.Where(t => t.Name == "Fail").First(),
                    TestCase = context.TestCases.Where(t => t.Id == 1).First()
                },
                new Step
                {
                    Id = 4,
                    Name = "Test cases can be created",
                    ItemStatus = context.ItemStatuses.Where(t => t.Name == "Not run").First(),
                    TestCase = context.TestCases.Where(t => t.Id == 1).First()
                },
                // Steps for second test case
                new Step
                {
                    Id = 5,
                    Name = "Can access page",
                    ItemStatus = context.ItemStatuses.Where(t => t.Name == "Pass").First(),
                    TestCase = context.TestCases.Where(t => t.Id == 2).First()
                },
                new Step
                {
                    Id = 6,
                    Name = "There's a way to allow editing of test cases",
                    ItemStatus = context.ItemStatuses.Where(t => t.Name == "Blocked").First(),
                    TestCase = context.TestCases.Where(t => t.Id == 2).First()
                },
                new Step
                {
                    Id = 7,
                    Name = "You can save edit the test case name and save changes",
                    ItemStatus = context.ItemStatuses.Where(t => t.Name == "Not run").First(),
                    TestCase = context.TestCases.Where(t => t.Id == 2).First()
                });
            context.SaveChanges();
        }
    }
}
