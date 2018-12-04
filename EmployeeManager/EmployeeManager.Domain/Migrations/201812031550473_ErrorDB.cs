namespace EmployeeManager.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ErrorId = c.Guid(nullable: false),
                        ErrorDateTime = c.DateTime(nullable: false),
                        ErrorMessage = c.String(),
                        StackTrace = c.String(),
                    })
                .PrimaryKey(t => t.ErrorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Errors");
        }
    }
}
