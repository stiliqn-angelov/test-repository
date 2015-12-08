using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using train_tickets_system.Models;
using train_tickets_system.ViewModels;

namespace train_tickets_system.Controllers
{
    static class Setter // Should implement filters instead and this is done stupidly
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        private static SelectList Cities { get; set; }
        public static SelectList getCities()
        {
            var citiesQuery = from d in db.Cities
                              select d;
            var cities = new Dictionary<int, string>();
            foreach (var city in citiesQuery)
            {
                cities.Add(city.CityId, city.Name);
            }

            Cities = new SelectList(cities, "Key", "Value");

            return Cities;
        }

        private static SelectList Hours { get; set; }
        public static SelectList getHours()
        {
            var hours = new Dictionary<int, string>()
                {
                    { 0, "00:00" },
                    { 1, "01:00" },
                    { 2, "02:00" },
                    { 3, "03:00" },
                    { 4, "04:00" },
                    { 5, "05:00" },
                    { 6, "06:00" },
                    { 7, "07:00" },
                    { 8, "08:00" },
                    { 9, "09:00" },
                    { 10, "10:00" },
                    { 11, "11:00" },
                    { 12, "12:00" },
                    { 13, "13:00" },
                    { 14, "14:00" },
                    { 15, "15:00" },
                    { 16, "16:00" },
                    { 17, "17:00" },
                    { 18, "18:00" },
                    { 19, "19:00" },
                    { 20, "20:00" },
                    { 21, "21:00" },
                    { 22, "22:00" },
                    { 23, "23:00" }
                };

            Hours = new SelectList(hours, "Key", "Value");

            return Hours;
        }

        private static SelectList Seats { get; set; }
        public static SelectList getSeats()
        {
            var seats = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Seats = new SelectList(seats);

            return Seats;
        }
    }

    public class TicketController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // INDEX
        public ActionResult Index()
        {
            return RedirectToAction("Search");
        }

        // SEARCH
        [Authorize]
        public ActionResult Search()
        {
            var viewModel = new SearchViewModel
            {
                Cities = Setter.getCities(),
                Hours = Setter.getHours(),
                DepartureDate = DateTime.Today
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Search(SearchViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                DateTime departure = viewModel.DepartureDate.AddHours(viewModel.Hour);
                DateTime departuredDay = departure.Date.AddDays(1);
                DateTime departureConstraint = DateTime.Today.AddDays(15);

                var trips = from d in db.Trips
                            select d;

                trips = trips.Where(r => r.Route.InitialCity.CityId == viewModel.InitialCityId)
                                        .Where(t => t.Route.TargetCity.CityId == viewModel.TargetCityId)
                                        .Where(r => r.DepartureTime >= departure)
                                        .Where(r => r.DepartureTime < departuredDay)
                                        .Where(r => r.DepartureTime < departureConstraint)
                                        .OrderBy(d => d.DepartureTime)
                                        .Take(3);

                return View("SearchResult", trips.ToList());
            }

            viewModel.Cities = Setter.getCities();
            viewModel.Hours = Setter.getHours();
            viewModel.DepartureDate = DateTime.Today;

            return View(viewModel);
        }

        // BOOK
        [Authorize]
        public ActionResult Book(int id)
        {
            Reservation ticket = new Reservation();
            ticket.Trip = db.Trips.Find(id);
            ticket.TripRefId = id;
            ViewBag.Seats = Setter.getSeats();

            return View(ticket);
        }

        /*[HttpPost]
        [Authorize]
        public ActionResult Book(Reservation ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.Trip = db.Trips.Find(ticket.TripRefId);
                ticket.Trip.SeatsTaken = db.SeatsTaken.Find(ticket.TripRefId);

                if (ticket.Trip.SeatsTaken == null)
                {
                    ticket.Trip.SeatsTaken = new SeatsTaken();
                    ticket.Trip.SeatsTaken.TripId = ticket.Trip.TrainRefId;
                    ticket.Trip.SeatsTaken.Trip = ticket.Trip.TripId;
                    if (ticket.PriceId == 1)
                    {
                        ticket.Trip.SeatsTaken.SeatsEconomical += ticket.Seats;
                    }
                    else
                    {
                        if (ticket.PriceId == 2)
                        {
                            ticket.Trip.SeatsTaken.SeatsBusiness += ticket.Seats;
                        }
                    }

                    var trip = db.Trips.Find(ticket.TripRefId);
                    trip.SeatsTaken = ticket.Trip.SeatsTaken;
                    ticket.Trip = trip;

                    db.Entry(trip).State = EntityState.Modified;
                    db.SeatsTakem.Add(ticket.Trip.SeatsTaken);
                }
                else
                {
                    ViewBag.Seats = Setter.getSeats();

                    if (ticket.PriceId == 1)
                    {
                        if (ticket.Trip.SeatsTaken.SeatsEconomical + ticket.Seats <= ticket.Trip.Train.econimicSeats)
                        {
                            ticket.Trip.SeatsTaken.SeatsEconomical += ticket.Seats;

                            db.Entry(ticket.Trip.SeatsTaken).State = EntityState.Modified;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Not enough free seats in economy class!");
                            return View(ticket);
                        }
                    }
                    else
                    {
                        if (ticket.Trip.SeatsTaken.SeatsBusiness + ticket.Seats <= ticket.Trip.Train.businessSeats)
                        {
                            ticket.Trip.SeatsTaken.SeatsBusiness += ticket.Seats;

                            db.Entry(ticket.Trip.SeatsTaken).State = EntityState.Modified;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Not enough free seats in business class!");
                            return View(ticket);
                        }
                    }
                }


                ticket.CustomerID = User.Identity.GetUserId();
                db.Reservations.Add(ticket);
                db.SaveChanges();

                return RedirectToRoute("Default", new { controller = "Ticket", action = "Search" });
            }

            return View(ticket);
        }*/
    }
}
