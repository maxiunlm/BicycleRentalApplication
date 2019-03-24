using BicycleRentalApplication.Rent.Dal.Rents;
using BicycleRentalApplication.Rent.Models.Models;
using BicycleRentalApplication.Rent.Models.Rents;
using System.Collections.Generic;

namespace BicycleRentalApplication.Rent.Core.Rents
{
    public class RentBusiness : IRentBusiness
    {
        public IRentData RentData { get; set; }

        public RentBusiness()
        {
            RentData = new RentData();
        }

        public void Create(RentModel rent)
        {
            VerifyDiscount(rent);
            CalculateReturnDate(rent);

            RentData.Create(rent);
        }

        public RentModel Get(int id)
        {
            RentModel rent = RentData.Get(id);
            return rent;
        }

        public void Update(RentModel rent)
        {
            VerifyDiscount(rent);
            CalculateReturnDate(rent);

            RentData.Update(rent);
        }

        public void Delete(int id)
        {
            RentData.Delete(id);
        }

        public List<RentModel> ListAll()
        {
            List<RentModel> rents = RentData.ListAll();
            return rents;
        }

        private void CalculateReturnDate(RentModel rent)
        {
            switch ((RentType)rent.Cost)
            {
                case RentType.hours:
                    rent.ReturnDate = rent.Date.AddHours(rent.Count);
                    break;
                case RentType.days:
                    rent.ReturnDate = rent.Date.AddDays(rent.Count);
                    break;
                case RentType.weeks:
                    rent.ReturnDate = rent.Date.AddDays(rent.Count * 7);
                    break;
            }
        }

        private void VerifyDiscount(RentModel rent)
        {
            decimal discount = 1;

            if (rent.Bicycles >= 3)
            {
                discount = 0.7M;
            }

            rent.Price = rent.Cost * rent.Count * rent.Bicycles * discount;
        }
    }
}
