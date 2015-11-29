namespace Zenchi.Repository.Ef.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Zenchi.Repository.Ef.ZenchiDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Zenchi.Repository.Ef.ZenchiDBContext context)
        {
            
        }
    }
}
