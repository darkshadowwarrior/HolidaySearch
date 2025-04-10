using HolidaySearch.Interfaces;
using HolidaySearch.Models;

namespace Search
{
    public class HolidaySearch
    {
        private IFlightService _flightService;
        private IHotelService _hotelService;

        public HolidaySearch(IFlightService flightService, IHotelService hotelService)
        {
            _flightService = flightService;
            _hotelService = hotelService;
        }

        public List<Holiday> Find(SearchCritera payload)
        {
            var flights = _flightService.FilterFlights(payload.From, payload.To, payload.DepartureDate);

            var hotels = _hotelService.FilterHotels(payload.To, payload.DepartureDate, payload.Duration);




            var holidays = (from flight in flights
                            from hotel in hotels
                            where (hotel.ArrivalDate >= flight.DepartureDate && hotel.ArrivalDate < flight.DepartureDate.AddDays(2))
                            select new Holiday
                            { 
                                Flight = flight,
                                Hotel = hotel,
                                TotalPrice = flight.Price + (hotel.PricePerNight * hotel.Nights)
                            })
                            .OrderBy(holiday => holiday.TotalPrice)
                            .ToList();

            return holidays;
                            
        }
    }
}