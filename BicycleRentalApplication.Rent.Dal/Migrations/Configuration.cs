using System.Data.Entity.Migrations;
using BicycleRentalApplication.Rent.Models.Models;

namespace BicycleRentalApplication.Rent.Dal.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BicycleRentalApplication.Rent.Dal.Model.Context";
        }

        protected override void Seed(Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
