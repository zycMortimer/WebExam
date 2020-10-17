namespace WebExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostDataAnnotations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "PostNum", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PostNum", c => c.Int(nullable: false));
        }
    }
}
