using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using NUnit.Framework;
using UsingViewComponents.Components;
using UsingViewComponents.Models;

namespace UsingViewComponents.Tests
{
    [TestFixture]
    public class SummaryViewComponentTests
    {
        [Test]
        public void TestSummary()
        {
            // Arrange
            var mockRepository = new Mock<ICityRepository>();
            mockRepository.SetupGet(m => m.Cities).Returns(new List<City> {
                new City { Population = 100 },
                new City { Population = 20000 },
                new City { Population = 1000000 },
                new City { Population = 500000 }
            });
            var viewComponent= new CitySummary(mockRepository.Object);
            // Act
            ViewViewComponentResult result= viewComponent.Invoke(false) as ViewViewComponentResult;
            // Assert
            Assert.IsInstanceOf<CityViewModel>(result.ViewData.Model);
            Assert.AreEqual(4, ((CityViewModel)result.ViewData.Model).Cities);
            Assert.AreEqual(1520100,((CityViewModel)result.ViewData.Model).Population);
        }
    }
}
