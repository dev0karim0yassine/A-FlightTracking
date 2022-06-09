using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class DetailsFlightViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Heure de décollage")]
        public DateTime FlightTakeOffTime { get; set; }

        [Display(Name = "Heure d'atterrissage")]
        public DateTime FlightLandingTime { get; set; }

        [Display(Name = "Avion")]
        public string Plane { get; set; }

        [Display(Name = "L'aéroport d'enregistrement")]
        public string CheckInAirport { get; set; }

        [Display(Name = "L'aéroport de départ")]
        public string CheckOutAirport { get; set; }

        [Display(Name = "Calculate distance")]
        public double CalculateDistance { get; set; }

        [Display(Name = "Flight duration")]
        public double CalculateFlightTime { get; set; }

        [Display(Name = "Take-Off Effort")]
        public double CalculateEffortTakeOff { get; set; }
    }
}
