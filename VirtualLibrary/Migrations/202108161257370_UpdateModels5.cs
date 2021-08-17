namespace VirtualLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BookAuthors", newName: "BookAuthor");
            RenameColumn(table: "dbo.BookAuthor", name: "Book_id", newName: "BookId");
            RenameColumn(table: "dbo.BookAuthor", name: "Author_id", newName: "AuthorId");
            RenameIndex(table: "dbo.BookAuthor", name: "IX_Book_id", newName: "IX_BookId");
            RenameIndex(table: "dbo.BookAuthor", name: "IX_Author_id", newName: "IX_AuthorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.BookAuthor", name: "IX_AuthorId", newName: "IX_Author_id");
            RenameIndex(table: "dbo.BookAuthor", name: "IX_BookId", newName: "IX_Book_id");
            RenameColumn(table: "dbo.BookAuthor", name: "AuthorId", newName: "Author_id");
            RenameColumn(table: "dbo.BookAuthor", name: "BookId", newName: "Book_id");
            RenameTable(name: "dbo.BookAuthor", newName: "BookAuthors");
        }
    }
}
