namespace WebExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "PostNum");
        }
    }
}
