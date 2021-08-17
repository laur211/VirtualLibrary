namespace VirtualLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "firstName", c => c.String(nullable: false));
            AddColumn("dbo.Authors", "lastName", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "feedback", c => c.String());
            DropColumn("dbo.Authors", "name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "feedback", c => c.String(nullable: false));
            DropColumn("dbo.Authors", "lastName");
            DropColumn("dbo.Authors", "firstName");
        }
    }
}
