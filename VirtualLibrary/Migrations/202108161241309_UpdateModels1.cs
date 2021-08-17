namespace VirtualLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookAuthors", "Book_id", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "Author_id", "dbo.Authors");
            DropIndex("dbo.BookAuthors", new[] { "Book_id" });
            DropIndex("dbo.BookAuthors", new[] { "Author_id" });
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
            DropTable("dbo.BookAuthors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_id = c.Int(nullable: false),
                        Author_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_id, t.Author_id });
            
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
            
            CreateIndex("dbo.BookAuthors", "Author_id");
            CreateIndex("dbo.BookAuthors", "Book_id");
            AddForeignKey("dbo.BookAuthors", "Author_id", "dbo.Authors", "id", cascadeDelete: true);
            AddForeignKey("dbo.BookAuthors", "Book_id", "dbo.Books", "id", cascadeDelete: true);
        }
    }
}
