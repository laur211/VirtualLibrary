namespace VirtualLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Authors", "bookId");
            DropColumn("dbo.Books", "authorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "authorId", c => c.Int(nullable: false));
            AddColumn("dbo.Authors", "bookId", c => c.Int(nullable: false));
        }
    }
}
