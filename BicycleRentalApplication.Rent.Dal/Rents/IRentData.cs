using System.Collections.Generic;
using BicycleRentalApplication.Rent.Models.Models;

namespace BicycleRentalApplication.Rent.Dal.Rents
{
    public interface IRentData
    {
        Context Context { get; set; }
        void Create(RentModel rent);
        void Delete(int id);
        RentModel Get(int id);
        List<RentModel> ListAll();
        void Update(RentModel rent);
    }
}