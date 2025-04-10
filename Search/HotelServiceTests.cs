using HolidaySearch.Data;
using HolidaySearch.Interfaces;
using HolidaySearch.Models;
using HolidaySearch.Services;
using Moq;

namespace HolidaySearch.Tests
{
    public class HotelServiceTests
    {
        private HotelService _service;
        private Mock<IHotelData> _hotelData;

        [Test]
        public void Should_Return_All_Flights()
        {
            _hotelData = new Mock<IHotelData>();

            _hotelData.Setup(x => x.GetHotels())
                .Returns(new List<Hotel>() {
                            new() { Id = 1, ArrivalDate = new DateTime(2022,11,5), Name = "Iberostar Grand Portals Nous", Nights = 7, PricePerNight = 100, LocalAirports = ["TFS"] },
                            new() { Id = 2, ArrivalDate = new DateTime(2022,11,5), Name = "Laguna Park 2", Nights = 7, PricePerNight = 50, LocalAirports = ["TFS"] },
                         });

            _service = new HotelService(_hotelData.Object);

            var result = _service.FilterHotels("TFS", "2022/11/05", 7);

            Assert.That(result, Is.Not.Null);
        }
    }
}
