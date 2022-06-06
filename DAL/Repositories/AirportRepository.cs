using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        readonly List<Airport> Airports = new List<Airport>
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

        public IEnumerable<Airport> LoadFake()
        { 
            return Airports;
        }
    }
}
