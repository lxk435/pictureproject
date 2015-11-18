namespace PictureProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changestring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InstagramImages", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InstagramImages", "Address");
        }
    }
}
