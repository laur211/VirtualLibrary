namespace VirtualLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BookAuthors");
            AddPrimaryKey("dbo.BookAuthors", new[] { "bookId", "authorId" });
            DropColumn("dbo.BookAuthors", "id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookAuthors", "id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.BookAuthors");
            AddPrimaryKey("dbo.BookAuthors", "id");
        }
    }
}
