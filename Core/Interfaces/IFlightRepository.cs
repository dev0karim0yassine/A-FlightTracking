using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    internal interface IFlightRepository
    {
        void BookFlight(Flight Flight);
        Flight GetFlight(int Id);
        double CalculateEffortTakeOff(Plane Plane);
        double CalculateFlightTime(DateTime FlightTakeOffTime, DateTime FlightLandingTime);
        double CalculateDistance(Airport CheckInAirport, Airport CheckOutAirport);
    }
}
