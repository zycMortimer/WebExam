namespace WebExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterDataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Registers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registers", "Password", c => c.String());
        }
    }
}
