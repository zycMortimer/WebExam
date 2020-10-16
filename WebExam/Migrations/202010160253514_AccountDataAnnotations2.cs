namespace WebExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountDataAnnotations2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "Account", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Accounts", "Account");
            DropColumn("dbo.Accounts", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "Account", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Accounts", "Id");
        }
    }
}
