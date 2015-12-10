namespace train_tickets_system.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<train_tickets_system.Models.ApplicationDbContext>
    {
        private DateTime timeCounter;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DatabaseMigrations";
        }

        protected override void Seed(train_tickets_system.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
          /*  if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();*/
            List<City> citiesList = new List<City>();
            citiesList.Clear();
            citiesList.Add(new City(1, "Brussels"));
            citiesList.Add(new City(2, "London"));
            citiesList.Add(new City(3, "Paris"));
            citiesList.Add(new City(4, "Amsterdam"));
            citiesList.Add(new City(5, "Berlin"));
            foreach (City cityV in citiesList)
            {
                context.Cities.AddOrUpdate(cityV);
            }
            List<Train> trainsList = new List<Train>();
            trainsList.Clear();
            for (int i = 0; i < citiesList.Count * (citiesList.Count - 1); i++)
            {
                trainsList.Add(new Train(i + 1, 50, 150, 97));
            }
            foreach (Train trainV in trainsList)
            {
                context.Trains.AddOrUpdate(trainV);
            }
            /*context.Cities.AddOrUpdate(
                 new Models.City(1, "Brussels"),
                 new Models.City(2, "London"),
                 new Models.City(3, "Paris"),
                 new Models.City(4, "Amsterdam"),
                 new Models.City(5, "Berlin"));*/
            List<Models.Route> routesList = new List<Models.Route>();
            routesList.Clear();

            routesList.Add(new Models.Route(1, context.Cities.Find(1), context.Cities.Find(2), 373));
            routesList.Add(new Models.Route(2, context.Cities.Find(1), context.Cities.Find(3), 312));
            routesList.Add(new Models.Route(3, context.Cities.Find(1), context.Cities.Find(4), 210));
            routesList.Add(new Models.Route(4, context.Cities.Find(1), context.Cities.Find(5), 765));
            routesList.Add(new Models.Route(5, context.Cities.Find(2), context.Cities.Find(1), 373));
            routesList.Add(new Models.Route(6, context.Cities.Find(2), context.Cities.Find(3), 464));
            routesList.Add(new Models.Route(7, context.Cities.Find(2), context.Cities.Find(4), 539));
            routesList.Add(new Models.Route(8, context.Cities.Find(2), context.Cities.Find(5), 1100));
            routesList.Add(new Models.Route(9, context.Cities.Find(3), context.Cities.Find(1), 312));
            routesList.Add(new Models.Route(10, context.Cities.Find(3), context.Cities.Find(2), 464));
            routesList.Add(new Models.Route(11, context.Cities.Find(3), context.Cities.Find(4), 506));
            routesList.Add(new Models.Route(12, context.Cities.Find(3), context.Cities.Find(5), 1055));
            routesList.Add(new Models.Route(13, context.Cities.Find(4), context.Cities.Find(1), 210));
            routesList.Add(new Models.Route(14, context.Cities.Find(4), context.Cities.Find(2), 539));
            routesList.Add(new Models.Route(15, context.Cities.Find(4), context.Cities.Find(3), 506));
            routesList.Add(new Models.Route(16, context.Cities.Find(4), context.Cities.Find(5), 654));
            routesList.Add(new Models.Route(17, context.Cities.Find(5), context.Cities.Find(1), 765));
            routesList.Add(new Models.Route(18, context.Cities.Find(5), context.Cities.Find(2), 1100));
            routesList.Add(new Models.Route(19, context.Cities.Find(5), context.Cities.Find(3), 1055));
            routesList.Add(new Models.Route(20, context.Cities.Find(5), context.Cities.Find(4), 654));

            foreach (Models.Route routeV in routesList)
            {
                context.Routes.AddOrUpdate(routeV);
            }
            context.Price.AddOrUpdate(
                new Models.Price(1, "economic", 0.11m),
                new Models.Price(2, "business", 0.16m));

            timeCounter = new DateTime(2015, 12, 10, 0, 0, 0);
            //List<Models.City> nontargetList = new List<Models.City>();
            Models.City cityBuffer = new Models.City();
            DateTime resetter = new DateTime();
            resetter = timeCounter;
            List<Models.Trip> tripsList = new List<Models.Trip>();
            tripsList.Clear();
            List<Models.Trip> routeFilteredTrips = new List<Models.Trip>();
            routeFilteredTrips.Clear();
            List<Models.Route> cityFilteredRoutes = new List<Models.Route>();
            cityFilteredRoutes.Clear();
            List<int> possibleRoutes = new List<int>();
            possibleRoutes.Clear();
         
            foreach (Models.Trip tripV in tripsList)
            {
                context.Trips.AddOrUpdate(tripV);
            }
        }
    }
}
