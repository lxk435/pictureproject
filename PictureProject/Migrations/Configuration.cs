namespace PictureProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PictureProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PictureProject.Models.PictureProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PictureProject.Models.PictureProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //
            context.InstagramImages.AddOrUpdate(
            x => x.Id,
            new InstagramImage() { Id = 1, Address = "http://1.bp.blogspot.com/-FTKHZ2sZOvY/TeH0DyNO4II/AAAAAAAAA4w/ihIseEnfaac/s1600/Funny-Dog.jpg" , Height = 150, Width = 150}
            );
            
        }
    }
}
