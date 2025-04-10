using HolidaySearch.Interfaces;
using HolidaySearch.Models;
using Moq;

namespace Search
{
    public class Tests
    {
        private HolidaySearch _search;
        private Mock<IFlightService> _flightService;
        private Mock<IHotelService> _holidayService;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CustomerOne_SearchReturns_Expected_Holiday()
        {
            _flightService = new Mock<IFlightService>();
            _flightService.Setup(fs => fs.FilterFlights(It.IsAny<string[]>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new List<Flight>()
            {
                new() { Id = 2, Airline = "Oceanic Airlines", DepartingFrom = "MAN", TravalingTo = "AGP", Price = 245, DepartureDate = new DateTime(2023,7,1) },
                new() { Id = 12, Airline = "Trans American Airlines", DepartingFrom = "MAN", TravalingTo = "AGP", Price = 202, DepartureDate = new DateTime(2023,10,25) }
            });

            _holidayService = new Mock<IHotelService>();
            _holidayService.Setup(fs => fs.FilterHotels(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new List<Hotel>()
            {
                new() { Id = 9, Name = "Nh Malaga", ArrivalDate = new DateTime(2023, 7, 1), PricePerNight = 83, Nights = 7 },
                new() { Id = 10, Name = "Barcelo Malaga", ArrivalDate = new DateTime(2023, 7, 5), PricePerNight = 45, Nights = 10 },
                new() { Id = 11, Name = "Parador De Malaga Gibralfaro", ArrivalDate = new DateTime(2023, 10, 16), PricePerNight = 100, Nights = 7  },
                new() { Id = 12, Name = "MS Maestranza Hotel", ArrivalDate = new DateTime(2023, 7, 1), PricePerNight = 45, Nights = 14  },
            });

            _search = new HolidaySearch(_flightService.Object, _holidayService.Object);

            var payload = new SearchCritera() { From = ["MAN"], To = "AGP", DepartureDate = "2023/07/01", Duration = 7 };

            var results = _search.Find(payload);

            Assert.That(results, Is.Not.Null);
            Assert.That(results.First().Flight.Id, Is.EqualTo(2));
            Assert.That(results.First().Hotel.Id, Is.EqualTo(9));
        }

        [Test]
        public void CustomerTwo_SearchReturns_Expected_Holiday()
        {
            _flightService = new Mock<IFlightService>();
            _flightService.Setup(fs => fs.FilterFlights(It.IsAny<string[]>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new List<Flight>()
            {
                new() { Id = 4, Airline = "Trans American Airlines", DepartingFrom = "LTN", TravalingTo = "PMI", Price = 153, DepartureDate = new DateTime(2023,6,15) },
                new() { Id = 6, Airline = "Fresh Airways", DepartingFrom = "LGW", TravalingTo = "PMI", Price = 75, DepartureDate = new DateTime(2023,6,15) }
            });

            _holidayService = new Mock<IHotelService>();
            _holidayService.Setup(fs => fs.FilterHotels(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new List<Hotel>()
            {
                new() { Id = 3, Name = "Sol Katmandu Park & Resort", ArrivalDate = new DateTime(2023, 6, 15), PricePerNight = 59, Nights = 14 },
                new() { Id = 4, Name = "Sol Katmandu Park & Resort", ArrivalDate = new DateTime(2023, 6, 15), PricePerNight = 59, Nights = 14 },
                new() { Id = 5, Name = "Sol Katmandu Park & Resort", ArrivalDate = new DateTime(2023, 6, 15), PricePerNight = 60, Nights = 10  },
                new() { Id = 13, Name = "Jumeirah Port Soller", ArrivalDate = new DateTime(2023, 6, 15), PricePerNight = 295, Nights = 10  },
            });

            _search = new HolidaySearch(_flightService.Object, _holidayService.Object);

            var payload = new SearchCritera() { From = ["LTN", "LGW"], To = "PMI", DepartureDate = "2023/06/15", Duration = 10 };

            var results = _search.Find(payload);

            Assert.That(results, Is.Not.Null);
            Assert.That(results.First().Flight.Id, Is.EqualTo(6));
            Assert.That(results.First().Hotel.Id, Is.EqualTo(5));
        }
    }
}