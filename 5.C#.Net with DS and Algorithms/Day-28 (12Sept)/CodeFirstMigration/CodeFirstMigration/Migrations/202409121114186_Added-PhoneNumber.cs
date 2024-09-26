namespace CodeFirstMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "PhoneNumber");
        }
    }
}
