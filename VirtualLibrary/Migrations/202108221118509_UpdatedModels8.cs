namespace VirtualLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authors", "Book_id", "dbo.Books");
            DropIndex("dbo.Authors", new[] { "Book_id" });
            DropColumn("dbo.Authors", "Book_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Book_id", c => c.Int());
            CreateIndex("dbo.Authors", "Book_id");
            AddForeignKey("dbo.Authors", "Book_id", "dbo.Books", "id");
        }
    }
}
