namespace WebExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookDataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "BookPicturePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "BookPicturePath", c => c.String());
        }
    }
}
