namespace VirtualLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAuthorModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "deathDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "deathDate", c => c.DateTime(nullable: false));
        }
    }
}
