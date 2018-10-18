namespace EmployeeManager.Domain.Migrations
{
    using EmployeeManager.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static EmployeeManager.Domain.Entities.Employee;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeManager.Domain.EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeManager.Domain.EmployeeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Employees.AddOrUpdate(x => x.EmployeeId,
                new Employee
                {
                    EmployeeId = Guid.Parse("91aff390-4be7-49d7-a74f-09fe1f6a3d83"),
                    FirstName = "Janet",
                    MiddleName = "G.",
                    LastName = "Carreiro",
                    DateHired = DateTime.Parse("2012-05-15"),
                    BirthDate = DateTime.Parse("1985-04-28"),
                    Salary = 43000.0m,
                    Recurrence = RecurrenceInterval.ANNUAL,
                    JobTitle = "Graphic Designer",
                    Department = "Graphics",
                    Availability = "Weekdays"

                });
        }
    }
}
