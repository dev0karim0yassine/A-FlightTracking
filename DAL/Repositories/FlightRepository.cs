using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;
using Core.Models;
using System.Linq;

namespace DAL.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        IList<Flight> Flights;

        public FlightRepository()
        {
            LoadFake();
        }

        public IEnumerable<Flight> LoadFake()
        {
            var Planes = new List<Plane>
            {
                new Plane
                {
                    Id = 1,
                    Consumption = 0,
                    Name = "Boeing 727"
                }
            };

            var Airports = new List<Airport>
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
                    PlaneId= Planes.First().Id,
                    CheckInAirportId= Airports.ToList()[0].Id,
                    CheckInAirport= Airports.ToList()[0],
                    CheckOutAirportId= Airports.ToList()[1].Id,
                    CheckOutAirport= Airports.ToList()[1],
                    FlightLandingTime= DateTime.Now,
                    FlightTakeOffTime = DateTime.Now.AddMinutes(120),
                }
            };

            return Flights;
        }
        
        public IEnumerable<Flight> GetFlights()
        {
            return Flights;
        }

        public Flight GetFlight(int Id)
        {
            return Flights.FirstOrDefault(f => f.Id == Id);
        }

        public void BookFlight(Flight Flight)
        {
            Flights.Add(Flight);
        }
        
        public void EditFlight(int id, Flight Flight)
        {
            var i = Flights.IndexOf(Flights.FirstOrDefault(f => f.Id == id));
            Flights[i] = Flight;
        }

        public double CalculateDistance(Airport CheckInAirport, Airport CheckOutAirport)
        {
            // The math module contains a function named toRadians which converts from degrees to radians.
            CheckInAirport.Longitude = (CheckInAirport.Longitude * Math.PI) / 180;
            CheckInAirport.Latitude = (CheckInAirport.Latitude * Math.PI) / 180;

            CheckOutAirport.Longitude = (CheckOutAirport.Longitude * Math.PI) / 180;
            CheckOutAirport.Latitude = (CheckOutAirport.Latitude * Math.PI) / 180;

            // Haversine formula
            double dlon = CheckOutAirport.Longitude - CheckInAirport.Longitude;
            double dlat = CheckOutAirport.Latitude - CheckInAirport.Latitude;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                       Math.Cos(CheckInAirport.Latitude) * Math.Cos(CheckOutAirport.Latitude) *
                       Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            // Radius of earth in kilometers. Use 3956 for miles
            double r = 6371;

            // calculate the result
            return (c * r);
        }

        public double CalculateEffortTakeOff(Plane Plane)
        {
            //logic missing, so this is just an exemple ;)
            return DateTime.Now.Subtract(DateTime.Now.AddMinutes(20)).TotalHours + Plane.Consumption;
        }

        public double CalculateFlightTime(DateTime FlightTakeOffTime, DateTime FlightLandingTime)
        {
            return FlightLandingTime.Subtract(FlightTakeOffTime).TotalHours;
        }
    }
}
