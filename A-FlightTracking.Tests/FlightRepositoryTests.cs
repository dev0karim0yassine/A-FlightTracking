using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;
using Core.Models;
using System.Linq;
using Moq;

namespace A_FlightTracking.Tests
{
    [TestClass]
    public class FlightRepositoryTests
    {
        private Mock<IFlightRepository> flightRepositoryMock { get; set; }
        private IFlightRepository flightRepository { get; set; }

        private IEnumerable<Flight> ExpectedFlightsInit { get; set; }
        private List<Flight> ExpectedFlightsExisting { get; set; }


        [TestInitialize]
        public void FlightRepositoryTestsInit()
        {
            flightRepositoryMock = new Mock<IFlightRepository>();
            flightRepository = flightRepositoryMock.Object;

            //Excpected values
            ExpectedFlightsExisting = new List<Flight>
            {
                new Flight
                {
                    Id= 1,
                    Plane= new Plane
                    {
                        Id = 1,
                        Consumption = 0,
                        Name = "Boeing 727"
                    },
                    PlaneId= 1,
                    CheckInAirportId= 1,
                    CheckInAirport= new Airport
                    {
                        Id = 1,
                        Name= "Aéroport de Paris-Charles de Gaulle",
                        Latitude = 40.9415053,
                        Longitude = -10.2917926
                    },
                    CheckOutAirportId= 2,
                    CheckOutAirport= new Airport
                    {
                        Id = 2,
                        Name= "Aéroport international Mohammed V de Casablanca",
                        Latitude = 33.3699749,
                        Longitude = -7.5879118
                    },
                    FlightLandingTime= DateTime.Now,
                    FlightTakeOffTime = DateTime.Now.AddMinutes(120),
                }
            };
            
            ExpectedFlightsInit = new List<Flight>
            {
                new Flight
                {
                    Id= 1,
                    Plane= new Plane
                    {
                        Id = 1,
                        Consumption = 0,
                        Name = "Boeing 727"
                    },
                    PlaneId= 1,
                    CheckInAirportId= 1,
                    CheckInAirport= new Airport
                    {
                        Id = 1,
                        Name= "Aéroport de Paris-Charles de Gaulle",
                        Latitude = 40.9415053,
                        Longitude = -10.2917926
                    },
                    CheckOutAirportId= 2,
                    CheckOutAirport= new Airport
                    {
                        Id = 2,
                        Name= "Aéroport international Mohammed V de Casablanca",
                        Latitude = 33.3699749,
                        Longitude = -7.5879118
                    },
                    FlightLandingTime= DateTime.Now,
                    FlightTakeOffTime = DateTime.Now.AddMinutes(120),
                }
            };

        }

        [TestMethod]
        public void LoadFake_WhenFlightsAreInitialized_ReturnFlights()
        {
            //Arrange
            flightRepositoryMock.Setup(f => f.LoadFake())
                .Returns(ExpectedFlightsInit);

            //Act
            var actualFlights = flightRepository.LoadFake();

            //Assert
            Assert.AreEqual(ExpectedFlightsInit, actualFlights);
        }
        
        [TestMethod]
        public void GetFlights_WhenFlightsAreNotNull_ReturnFlights()
        {
            //Arrange
            flightRepositoryMock.Setup(f => f.GetFlights())
                .Returns(ExpectedFlightsExisting);

            //Act
            List<Flight> actualFlights = flightRepository.GetFlights().ToList();

            //Assert
            Assert.AreEqual(ExpectedFlightsExisting, actualFlights);
        }
        
        [TestMethod]
        public void GetFlight_WhenFlightIsFound_ReturnFlight()
        {
            //Arrange
            flightRepositoryMock.Setup(f => f.GetFlight(1))
                .Returns(ExpectedFlightsExisting.First());

            //Act
            var actualFlight = flightRepository.GetFlight(1);

            //Assert
            Assert.AreEqual(ExpectedFlightsExisting.First(), actualFlight);
        }
        
        [TestMethod]
        public void GetFlight_WhenFlightIsNotFound_ReturnNull()
        {
            //Arrange
            flightRepositoryMock.Setup(f => f.GetFlight(11))
                .Returns<Flight>(null);

            //Act
            var actualFlight = flightRepository.GetFlight(11);
            Flight ExpectedFlight = null;

            //Assert
            Assert.AreEqual(ExpectedFlight, actualFlight);
        }
        
        [TestMethod]
        public void BookFlight_WhenSuccessed_FlightIsFound()
        {
            //Arrange
            Flight ExpectedFlight = new Flight
            {
                Id = 2,
                Plane = new Plane
                {
                    Id = 1,
                    Consumption = 0,
                    Name = "Boeing 727"
                },
                PlaneId = 1,
                CheckInAirportId = 1,
                CheckInAirport = new Airport
                {
                    Id = 1,
                    Name = "Aéroport de Paris-Charles de Gaulle",
                    Latitude = 40.9415053,
                    Longitude = -10.2917926
                },
                CheckOutAirportId = 2,
                CheckOutAirport = new Airport
                {
                    Id = 2,
                    Name = "Aéroport international Mohammed V de Casablanca",
                    Latitude = 33.3699749,
                    Longitude = -7.5879118
                },
                FlightLandingTime = DateTime.Now,
                FlightTakeOffTime = DateTime.Now.AddMinutes(120),
            };

            ExpectedFlightsExisting.Add(ExpectedFlight);
            flightRepositoryMock.Setup(f => f.GetFlights())
               .Returns(ExpectedFlightsExisting);

            //Act
            flightRepository.BookFlight(ExpectedFlight);
            var actualFlights = flightRepository.GetFlights();

            //Assert
            Assert.AreEqual(2, actualFlights.Count());
        }

        [TestMethod]
        public void CalculateDistance_WhenCheckInAndCheckOutAirports_ReturnNull()
        {
            //Arrange
            flightRepositoryMock.Setup(f =>
                f.CalculateDistance(ExpectedFlightsInit.First().CheckInAirport, ExpectedFlightsInit.First().CheckOutAirport))
                .Returns(Math.Round(875.21987854021609));

            //Act
            var actualDistance = flightRepository.CalculateDistance(ExpectedFlightsInit.First().CheckInAirport, ExpectedFlightsInit.First().CheckOutAirport);
            double ExpectedDistance = Math.Round(875.21987854021609);

            //Assert
            Assert.AreEqual(actualDistance, ExpectedDistance);
        }

        [TestMethod]
        public void CalculateEffortTakeOff_WhenPlaneConsumptionIsNotNull_ReturnEffortTakeOff()
        {
            //Arrange
            flightRepositoryMock.Setup(f =>
                f.CalculateEffortTakeOff(ExpectedFlightsInit.First().Plane))
                .Returns(Math.Round(175.419));

            //Act
            var actualEffortTakeOff = flightRepository.CalculateEffortTakeOff(ExpectedFlightsInit.First().Plane);
            double ExpectedEffortTakeOff = Math.Round(175.419);

            //Assert
            Assert.AreEqual(actualEffortTakeOff, ExpectedEffortTakeOff);
        }

        [TestMethod]
        public void CalculateFlightTime_WhenFlightTimesAreNotNull_ReturnFlightTimeTotalHours()
        {
            //Arrange
            DateTime FlightTakeOffTime = DateTime.Now, FlightLandingTime = DateTime.Now.AddMinutes(120);
            double ExpectedFlightTimeTotalHours = FlightLandingTime.Subtract(FlightTakeOffTime).TotalHours;

            flightRepositoryMock.Setup(f =>
                f.CalculateFlightTime(ExpectedFlightsInit.First().FlightTakeOffTime, FlightLandingTime))
                .Returns(ExpectedFlightTimeTotalHours);

            //Act
            var actualFlightTimeTotalHours = flightRepository.CalculateFlightTime(ExpectedFlightsInit.First().FlightTakeOffTime, FlightLandingTime);

            //Assert
            Assert.AreEqual(actualFlightTimeTotalHours, ExpectedFlightTimeTotalHours);
        }
    }
}
