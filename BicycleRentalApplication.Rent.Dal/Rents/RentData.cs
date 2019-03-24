using BicycleRentalApplication.Rent.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace BicycleRentalApplication.Rent.Dal.Rents
{
    public class RentData : IRentData
    {
        private Context context;

        public Context Context { get => context; set => context = value; }

        public RentData()
        {
            context = new Context();
        }

        public void Create(RentModel rent)
        {
            context.Rent.Add(rent);

            context.SaveChanges();
        }

        public RentModel Get(int id)
        {
            return context.Rent.Where(o => o.Id == id).SingleOrDefault() ?? new RentModel();
        }

        public void Update(RentModel rent)
        {
            RentModel dbRent = context.Rent.Where(o => o.Id == rent.Id).Single();

            dbRent.Date = rent.Date;
            dbRent.ReturnDate = rent.ReturnDate;
            dbRent.Price = rent.Price;
            dbRent.Cost = rent.Cost;
            dbRent.Count = rent.Count;
            dbRent.Bicycles = rent.Bicycles;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            RentModel user = context.Rent.Where(o => o.Id == id).Single();
            context.Rent.Remove(user);

            context.SaveChanges();
        }

        public List<RentModel> ListAll()
        {
            return context.Rent.OrderBy(o => o.ReturnDate).ThenBy(o => o.Date).ToList();
        }
    }
}
