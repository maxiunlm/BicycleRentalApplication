using System.Data.Entity;

namespace BicycleRentalApplication.Rent.Models.Models
{
    public class Context : DbContext
    {
        public virtual DbSet<RentModel> Rent { get; set; }

        public Context()
            : base("name=DefaultConnection")
        {
        }
    }
}
