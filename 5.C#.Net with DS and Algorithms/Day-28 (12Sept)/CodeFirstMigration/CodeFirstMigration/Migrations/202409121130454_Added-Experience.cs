namespace CodeFirstMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedExperience : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Experience", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Experience");
        }
    }
}
