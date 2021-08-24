namespace VirtualLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BookAuthor", newName: "BookAuthors1");
            RenameColumn(table: "dbo.BookAuthors1", name: "BookId", newName: "Book_id");
            RenameColumn(table: "dbo.BookAuthors1", name: "AuthorId", newName: "Author_id");
            RenameIndex(table: "dbo.BookAuthors1", name: "IX_BookId", newName: "IX_Book_id");
            RenameIndex(table: "dbo.BookAuthors1", name: "IX_AuthorId", newName: "IX_Author_id");
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        bookId = c.Int(nullable: false),
                        authorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Authors", t => t.authorId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.bookId, cascadeDelete: true)
                .Index(t => t.bookId)
                .Index(t => t.authorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookAuthors", "bookId", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "authorId", "dbo.Authors");
            DropIndex("dbo.BookAuthors", new[] { "authorId" });
            DropIndex("dbo.BookAuthors", new[] { "bookId" });
            DropTable("dbo.BookAuthors");
            RenameIndex(table: "dbo.BookAuthors1", name: "IX_Author_id", newName: "IX_AuthorId");
            RenameIndex(table: "dbo.BookAuthors1", name: "IX_Book_id", newName: "IX_BookId");
            RenameColumn(table: "dbo.BookAuthors1", name: "Author_id", newName: "AuthorId");
            RenameColumn(table: "dbo.BookAuthors1", name: "Book_id", newName: "BookId");
            RenameTable(name: "dbo.BookAuthors1", newName: "BookAuthor");
        }
    }
}
