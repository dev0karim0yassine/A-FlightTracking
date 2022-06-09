using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Core.Interfaces;
using DAL.Repositories;
using Moq;
using Core.Models;

namespace A_FlightTracking.Tests
{
    [TestClass]
    public class AirportRepositoryTests
    {
        List<Airport> ExpectedAirportsOK;

       [TestMethod]
        public void LoadFake_WhenAirportsAreInitialized_ReturnsAirports()
        {
            //Arrange
            Mock<IAirportRepository> airportRepository = new Mock<IAirportRepository>();
            ExpectedAirportsOK = new List<Airport>
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

            //Act
            airportRepository.Setup(m => m.LoadFake())
                .Returns(ExpectedAirportsOK);

            IAirportRepository repository = airportRepository.Object;
            var actual = repository.LoadFake();

            //Assert
            Assert.AreEqual(actual, ExpectedAirportsOK);
        }
    }
}
