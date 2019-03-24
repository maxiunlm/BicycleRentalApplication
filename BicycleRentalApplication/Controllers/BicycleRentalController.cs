using BicycleRentalApplication.Rent.Core.Rents;
using BicycleRentalApplication.Rent.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BicycleRentalApplication.Controllers
{
    public class BicycleRentalController : Controller, IBicycleRentalController
    {
        internal IRentBusiness RentBusiness { get; set; }

        public BicycleRentalController()
        {
            RentBusiness = new RentBusiness();
        }

        public ActionResult Index()
        {
            List<RentModel> rents = RentBusiness.ListAll();
            return View(rents);
        }

        public ActionResult Details(int id)
        {
            RentModel rent = RentBusiness.Get(id);
            return View(rent);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RentModel rent)
        {
            try
            {
                RentBusiness.Create(rent);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            RentModel rent = RentBusiness.Get(id);
            return View(rent);
        }

        [HttpPost]
        public ActionResult Edit(RentModel rent)
        {
            RentBusiness.Update(rent);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            RentModel rent = RentBusiness.Get(id);
            return View(rent);
        }

        [HttpPost]
        public ActionResult Delete(RentModel rent)
        {
            RentBusiness.Delete(rent.Id);

            return RedirectToAction("Index");
        }
    }
}
