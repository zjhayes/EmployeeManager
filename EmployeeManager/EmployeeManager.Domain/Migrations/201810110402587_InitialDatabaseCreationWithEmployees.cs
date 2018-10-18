namespace EmployeeManager.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreationWithEmployees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        DateHired = c.DateTime(nullable: false),
                        BirthDate = c.DateTime(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Recurrence = c.Int(nullable: false),
                        JobTitle = c.String(),
                        Department = c.String(),
                        Availability = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
