namespace CircularManagementSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CircularManagementSystem.DAL.ContextClass>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CircularManagementSystem.DAL.ContextClass";
        }

        protected override void Seed(CircularManagementSystem.DAL.ContextClass context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
