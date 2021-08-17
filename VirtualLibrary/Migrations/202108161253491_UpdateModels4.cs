namespace VirtualLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                        birthDate = c.DateTime(nullable: false),
                        deathDate = c.DateTime(),
                        bookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50),
                        resume = c.String(),
                        content = c.String(nullable: false),
                        feedbackNote = c.Int(nullable: false),
                        feedback = c.String(),
                        authorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookAuthors", "Author_id", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_id", "dbo.Books");
            DropIndex("dbo.BookAuthors", new[] { "Author_id" });
            DropIndex("dbo.BookAuthors", new[] { "Book_id" });
            DropTable("dbo.BookAuthors");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
