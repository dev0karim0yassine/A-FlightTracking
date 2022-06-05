using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class CreateFlightViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Heure de décollage")]
        public DateTime FlightTakeOffTime { get; set; }

        [Required]
        [Display(Name = "Heure d'atterrissage")]
        public DateTime FlightLandingTime { get; set; }

        [Required]
        [Display(Name = "Avion")]
        public int PlaneId { get; set; }
        public IEnumerable<Plane> Planes { get; set; }

        [Required]
        [Display(Name = "L'aéroport d'enregistrement")]
        public int CheckInAirportId { get; set; }
        public IEnumerable<Airport> CheckInAirport { get; set; }

        [Required]
        [Display(Name = "L'aéroport de départ")]
        public int CheckOutAirportId { get; set; }
        public IEnumerable<Airport> CheckOutAirport { get; set; }
    }
}
