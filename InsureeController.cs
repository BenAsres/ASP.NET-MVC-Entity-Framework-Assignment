using System.Linq;
using System.Web.Mvc;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class InsureeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // Starting with a base amount of $50/month
                decimal quote = 50.00m;

                // Age-based charge
                if (insuree.Age <= 18)
                {
                    quote += 100;
                }
                else if (insuree.Age >= 19 && insuree.Age <= 25)
                {
                    quote += 50;
                }
                else if (insuree.Age >= 26)
                {
                    quote += 25;
                }

                // Car year-based charge
                if (insuree.CarYear < 2000)
                {
                    quote += 25;
                }
                else if (insuree.CarYear > 2015)
                {
                    quote += 25;
                }

                // Car make-based charge
                if (insuree.CarMake.ToLower() == "porsche")
                {
                    quote += 25;

                    // Additional charge if model is a Porsche 911 Carrera
                    if (insuree.CarModel.ToLower() == "911 carrera")
                    {
                        quote += 25;
                    }
                }

                // Speeding tickets charge
                quote += insuree.SpeedingTickets * 10;

                // DUI charge (25% increase)
                if (insuree.HasDUI)
                {
                    quote *= 1.25m;
                }

                // Full coverage charge (50% increase)
                if (insuree.HasFullCoverage)
                {
                    quote *= 1.50m;
                }

                // Save the calculated quote to the Insuree object
                insuree.Quote = quote;

                // Save the insuree to the database
                db.Insurees.Add(insuree);
                db.SaveChanges();

                return RedirectToAction("Index"); // Redirect to the list of all insurees
            }

            return View(insuree);
        }

        // GET: Insuree/Admin
        public ActionResult Admin()
        {
            var insurees = db.Insurees.ToList();
            return View(insurees);
        }
    }
}
