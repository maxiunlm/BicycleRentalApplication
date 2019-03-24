using System.Collections.Generic;
using BicycleRentalApplication.Rent.Dal.Rents;
using BicycleRentalApplication.Rent.Models.Models;

namespace BicycleRentalApplication.Rent.Core.Rents
{
    public interface IRentBusiness
    {
        IRentData RentData { get; set; }

        void Create(RentModel rent);
        void Delete(int id);
        RentModel Get(int id);
        List<RentModel> ListAll();
        void Update(RentModel rent);
    }
}