namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Headings", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contents", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contents", "UpdatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Headings", "HeadingDate");
            DropColumn("dbo.Contents", "ContentDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "ContentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Headings", "HeadingDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contents", "UpdatedDate");
            DropColumn("dbo.Contents", "CreatedDate");
            DropColumn("dbo.Headings", "UpdatedDate");
            DropColumn("dbo.Headings", "CreatedDate");
        }
    }
}
