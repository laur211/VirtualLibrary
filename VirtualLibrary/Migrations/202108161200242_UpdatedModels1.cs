namespace VirtualLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_id = c.Int(nullable: false),
                        Author_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_id, t.Author_id })
                .ForeignKey("dbo.Books", t => t.Book_id, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_id, cascadeDelete: true)
                .Index(t => t.Book_id)
                .Index(t => t.Author_id);
            
            AddColumn("dbo.Authors", "bookId", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "authorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookAuthors", "Author_id", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_id", "dbo.Books");
            DropIndex("dbo.BookAuthors", new[] { "Author_id" });
            DropIndex("dbo.BookAuthors", new[] { "Book_id" });
            DropColumn("dbo.Books", "authorId");
            DropColumn("dbo.Authors", "bookId");
            DropTable("dbo.BookAuthors");
        }
    }
}
