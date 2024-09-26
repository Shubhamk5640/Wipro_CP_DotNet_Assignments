namespace CodeFirstMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "City", c => c.String());
            AddColumn("dbo.Employees", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Role");
            DropColumn("dbo.Employees", "City");
        }
    }
}
