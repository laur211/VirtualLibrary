namespace VirtualLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookAuthors1", "Book_id", "dbo.Books");
            DropForeignKey("dbo.BookAuthors1", "Author_id", "dbo.Authors");
            DropIndex("dbo.BookAuthors1", new[] { "Book_id" });
            DropIndex("dbo.BookAuthors1", new[] { "Author_id" });
            DropTable("dbo.BookAuthors1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookAuthors1",
                c => new
                    {
                        Book_id = c.Int(nullable: false),
                        Author_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_id, t.Author_id });
            
            CreateIndex("dbo.BookAuthors1", "Author_id");
            CreateIndex("dbo.BookAuthors1", "Book_id");
            AddForeignKey("dbo.BookAuthors1", "Author_id", "dbo.Authors", "id", cascadeDelete: true);
            AddForeignKey("dbo.BookAuthors1", "Book_id", "dbo.Books", "id", cascadeDelete: true);
        }
    }
}
