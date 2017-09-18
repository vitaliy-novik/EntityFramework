namespace EntityFrameworkTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_1_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        Employee_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.CreditCardID)
                .ForeignKey("Northwind.Employees", t => t.Employee_EmployeeID)
                .Index(t => t.Employee_EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "Employee_EmployeeID", "Northwind.Employees");
            DropIndex("dbo.CreditCards", new[] { "Employee_EmployeeID" });
            DropTable("dbo.CreditCards");
        }
    }
}
