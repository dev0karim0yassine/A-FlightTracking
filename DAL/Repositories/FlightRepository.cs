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
        private readonly DataContext _dataContext;
        public FlightRepository()
        {
            _dataContext = new DataContext();
        }

        public IEnumerable<Flight> GetFlights()
        {
            return _dataContext.Flights;
        }

        public Flight GetFlight(int Id)
        {
            return _dataContext.Flights.FirstOrDefault(f => f.Id == Id);
        }

        public void BookFlight(Flight Flight)
        {
            _dataContext.Flights.Add(Flight);
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
