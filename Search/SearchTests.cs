using HolidaySearch.Interfaces;
using HolidaySearch.Models;
using HolidaySearch.Services;
using Moq;

namespace Search
{
    public class Tests
    {
        private HolidayService _search;
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

            _search = new HolidayService(_flightService.Object, _holidayService.Object);

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

            _search = new HolidayService(_flightService.Object, _holidayService.Object);

            var payload = new SearchCritera() { From = ["LTN", "LGW"], To = "PMI", DepartureDate = "2023/06/15", Duration = 10 };

            var results = _search.Find(payload);

            Assert.That(results, Is.Not.Null);
            Assert.That(results.First().Flight.Id, Is.EqualTo(6));
            Assert.That(results.First().Hotel.Id, Is.EqualTo(5));
        }

        [Test]
        public void CustomerThree_SearchReturns_Expected_Holiday()
        {
            _flightService = new Mock<IFlightService>();
            _flightService.Setup(fs => fs.FilterFlights(It.IsAny<string[]>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new List<Flight>()
            {
                new() { Id = 1, DepartingFrom = "MAN", TravalingTo = "TFS", DepartureDate = new DateTime(2023,07,01), Price = 470, Airline = "First Class Air" },
                new() { Id = 2, DepartingFrom = "MAN", TravalingTo = "AGP", DepartureDate = new DateTime(2023,07,01), Price = 245, Airline = "Oceanic Airlines" },
                new() { Id = 3, DepartingFrom = "MAN", TravalingTo = "PMI", DepartureDate = new DateTime(2023,06,15), Price = 170, Airline = "Trans American Airlines" },
                new() { Id = 4, DepartingFrom = "LTN", TravalingTo = "PMI", DepartureDate = new DateTime(2023,06,15), Price = 153, Airline = "Trans American Airlines" },
                new() { Id = 5, DepartingFrom = "MAN", TravalingTo = "PMI", DepartureDate = new DateTime(2023,06,15), Price = 130, Airline = "Fresh Airways" },
                new() { Id = 6, DepartingFrom = "LGW", TravalingTo = "PMI", DepartureDate = new DateTime(2023,06,15), Price = 75, Airline = "Fresh Airways" },
                new() { Id = 7, DepartingFrom = "MAN", TravalingTo = "LPA", DepartureDate = new DateTime(2022,11,10), Price = 125, Airline = "Trans American Airlines" },
                new() { Id = 8, DepartingFrom = "MAN", TravalingTo = "LPA", DepartureDate = new DateTime(2023,11,10), Price = 175, Airline = "Fresh Airways" },
                new() { Id = 9, DepartingFrom = "MAN", TravalingTo = "AGP", DepartureDate = new DateTime(2023,04,11), Price = 140, Airline = "Fresh Airways" },
                new() { Id = 10, DepartingFrom = "LGW", TravalingTo = "AGP", DepartureDate = new DateTime(2023,07,01), Price = 225, Airline = "First Class Air" },
                new() { Id = 11, DepartingFrom = "LGW", TravalingTo = "AGP", DepartureDate = new DateTime(2023,07,01), Price = 155, Airline = "First Class Air" },
                new() { Id = 12, DepartingFrom = "MAN", TravalingTo = "AGP", DepartureDate = new DateTime(2023,10,25), Price = 202, Airline = "Trans American Airlines" },
            });

            _holidayService = new Mock<IHotelService>();
            _holidayService.Setup(fs => fs.FilterHotels(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new List<Hotel>()
            {
                new() { Id = 6, Name = "Club Maspalomas Suites and Spa", ArrivalDate = new DateTime(2022, 11, 10), PricePerNight = 75, Nights = 14, LocalAirports = ["LPA"] },
                new() { Id = 7, Name = "Club Maspalomas Suites and Spa", ArrivalDate = new DateTime(2022, 09, 10), PricePerNight = 76, Nights = 14, LocalAirports = ["LPA"] },
                new() { Id = 8, Name = "Boutique Hotel Cordial La Peregrina", ArrivalDate = new DateTime(2022, 10, 10), PricePerNight = 45, Nights = 7  },

            });

            _search = new HolidayService(_flightService.Object, _holidayService.Object);

            var payload = new SearchCritera() { From = [], To = "LPA", DepartureDate = "2022/11/10", Duration = 14 };

            var results = _search.Find(payload);

            Assert.That(results, Is.Not.Null);
            Assert.That(results.First().Flight.Id, Is.EqualTo(7));
            Assert.That(results.First().Hotel.Id, Is.EqualTo(6));
        }
    }
}