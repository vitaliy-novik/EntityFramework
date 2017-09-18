namespace EntityFrameworkTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_1_3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Northwind.Region", newName: "Regions");
            AddColumn("Northwind.Customers", "FoundationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("Northwind.Customers", "FoundationDate");
            RenameTable(name: "Northwind.Regions", newName: "Region");
        }
    }
}
