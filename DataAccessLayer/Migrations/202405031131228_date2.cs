namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Headings", "CreatedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Headings", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
