using System.Web.Mvc;
using BicycleRentalApplication.Rent.Models.Models;

namespace BicycleRentalApplication.Controllers
{
    public interface IBicycleRentalController
    {
        ActionResult Create();
        ActionResult Create(RentModel rent);
        ActionResult Delete(int id);
        ActionResult Delete(RentModel rent);
        ActionResult Details(int id);
        ActionResult Edit(int id);
        ActionResult Edit(RentModel rent);
        ActionResult Index();
    }
}