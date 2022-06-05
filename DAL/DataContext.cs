using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;
using System.Linq;

namespace DAL
{
    internal class DataContext
    {
        public IEnumerable<Plane> Planes;
        public IEnumerable<Airport> Airports;
        public IList<Flight> Flights;

        public DataContext()
        {
            Planes = new List<Plane>
            {
                new Plane
                {
                    Id = 1,
                    Consumption = 0,
                    Name = "Boeing 727"
                }
            };

            Airports = new List<Airport>
            {
                new Airport
                {
                    Id = 1,
                    Name= "Aéroport de Paris-Charles de Gaulle",
                    Latitude = 40.9415053,
                    Longitude = -10.2917926
                },
                new Airport
                {
                    Id = 2,
                    Name= "Aéroport international Mohammed V de Casablanca",
                    Latitude = 33.3699749,
                    Longitude = -7.5879118
                },
            };

            Flights = new List<Flight>
            {
                new Flight
                {
                    Id= 1,
                    Plane= Planes.First(),
                    CheckInAirport= Airports.ToList()[0],
                    CheckOutAirport= Airports.ToList()[1],
                    FlightLandingTime= DateTime.Now,
                    FlightTakeOffTime = DateTime.Now.AddMinutes(120),
                }
            };
        }
    }
}
