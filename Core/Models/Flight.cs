﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public DateTime FlightTakeOffTime { get; set; }
        public DateTime FlightLandingTime { get; set; }
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }
        public int CheckInAirportId { get; set; }
        public Airport CheckInAirport { get; set; }
        public int CheckOutAirportId { get; set; }
        public Airport CheckOutAirport { get; set; }
    }
}
