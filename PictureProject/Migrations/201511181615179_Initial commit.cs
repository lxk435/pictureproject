namespace PictureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialcommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstagramImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InstagramImages");
        }
    }
}
