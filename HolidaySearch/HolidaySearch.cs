using HolidaySearch.Interfaces;
using HolidaySearch.Models;

namespace Search
{
    public class HolidaySearch : IHolidaySearch
    {
        private IFlightService _flightService;
        private IHotelService _hotelService;

        public HolidaySearch(IFlightService flightService, IHotelService hotelService)
        {
            _flightService = flightService;
            _hotelService = hotelService;
        }

        public List<Holiday> Find(SearchCritera critera)
        {
            var flights = _flightService.FilterFlights(critera.From, critera.To, critera.DepartureDate);

            var hotels = _hotelService.FilterHotels(critera.To, critera.DepartureDate, critera.Duration);

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