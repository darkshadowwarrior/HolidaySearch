using HolidaySearch.Interfaces;
using HolidaySearch.Models;
using HolidaySearch.Services;
using Moq;

namespace HolidaySearch.Tests
{
    public class FlightServiceTests
    {
        private FlightService _service;
        private Mock<IFlightData> _flightData;

        [Test]
        public void Should_Return_All_Flights()
        {
            _flightData = new Mock<IFlightData>();

            _flightData.Setup(x => x.GetFlights())
                .Returns(new List<Flight>() {
                            new() { Airline = "", DepartingFrom = "", DepartureDate = new DateTime(), Id = 1, Price = 20, TravalingTo = "AGP" },
                            new() { Airline = "", DepartingFrom = "", DepartureDate = new DateTime(), Id = 1, Price = 20, TravalingTo = "AGP" },
                            new() { Airline = "", DepartingFrom = "", DepartureDate = new DateTime(), Id = 1, Price = 20, TravalingTo = "AGP" }
                         });

                    _service = new FlightService(_flightData.Object);

            var result = _service.FilterFlights(["MAN"], "AGP", "2023/07/01");

            Assert.That(result, Is.Not.Null);
        }
    }
}
