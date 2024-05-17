﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messageIsDeletedColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsDeleted");
        }
    }
}
