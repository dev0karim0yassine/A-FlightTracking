using Core.Models;
using Web.ViewModels;
using System.Collections.Generic;

namespace Web.Extensions
{
    public static class FlightExtensionMethods
    {
        public static CreateFlightViewModel MapDetailsFlight(this Flight flight,
            IEnumerable<Plane> planes,
            IEnumerable<Airport> airports)
        {
            return new CreateFlightViewModel
            {
                Id = flight.Id,
                CheckInAirportId = flight.CheckInAirportId,
                CheckOutAirportId = flight.CheckOutAirportId,
                PlaneId = flight.PlaneId,
                FlightTakeOffTime = flight.FlightTakeOffTime,
                FlightLandingTime = flight.FlightLandingTime,
                Planes = planes,
                CheckInAirport = airports,
                CheckOutAirport = airports
            };
        }
        
        public static Flight MapListFlight(this Flight flight,
            Plane plane,
            Airport checkInAirport,
            Airport checkOutAirport)
        {
            return new Flight
            {
                Id = flight.Id,
                CheckInAirportId = flight.CheckInAirportId,
                CheckOutAirportId = flight.CheckOutAirportId,
                PlaneId = flight.PlaneId,
                FlightTakeOffTime = flight.FlightTakeOffTime,
                FlightLandingTime = flight.FlightLandingTime,
                Plane = plane,
                CheckInAirport = checkInAirport,
                CheckOutAirport = checkOutAirport
            };
        }
        
        public static DetailsFlightViewModel MapDetailsFlightViewModel(this Flight flight,
            double calculateDistance,
            double calculateEffortTakeOff,
            double calculateFlightTime,
            string plane,
            string checkInAirport,
            string checkOutAirport)
        {
            return new DetailsFlightViewModel
            {
                Id = flight.Id,
                CalculateDistance = 0,
                CalculateEffortTakeOff = 0,
                CalculateFlightTime = 0,
                FlightTakeOffTime = flight.FlightTakeOffTime,
                FlightLandingTime = flight.FlightLandingTime,
                Plane = plane,
                CheckInAirport = checkInAirport,
                CheckOutAirport = checkOutAirport
            };
        }
        
        public static CreateFlightViewModel InitFlightViewModel(this CreateFlightViewModel flight,
            IEnumerable<Plane> planes,
            IEnumerable<Airport> airports)
        {
            return new CreateFlightViewModel
            {
                Planes = planes,
                CheckInAirport = airports,
                CheckOutAirport = airports
            };
        }
    }
}
