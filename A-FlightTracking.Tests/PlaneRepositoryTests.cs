using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Interfaces;
using Core.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace A_FlightTracking.Tests
{
    [TestClass]
    public class PlaneRepositoryTests
    {
        IEnumerable<Plane> ExpectedPlanesOK;

        [TestMethod]
        public void LoadFake_WhenPlanesAreInitialized_ReturnsPlanes()
        {
            //Arrange
            ExpectedPlanesOK = new List<Plane>
            {
                new Plane
                {
                    Id = 1,
                    Consumption = 0,
                    Name = "Boeing 727"
                }
            };

            Mock<IPlaneRepository> planeRepositoryMock = new Mock<IPlaneRepository>();
            planeRepositoryMock.Setup(m => m.LoadFake())
                .Returns(ExpectedPlanesOK);
            //Act
            IPlaneRepository planeRepository = planeRepositoryMock.Object;
            IEnumerable<Plane> Planes = planeRepository.LoadFake();

            //Assert
            Assert.AreEqual(ExpectedPlanesOK, Planes);
        }
    }
}
