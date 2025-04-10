using HolidaySearch.Interfaces;
using HolidaySearch.Models;

namespace HolidaySearch.Services
{
    public class FlightService : IFlightService
    {
        private IFlightData _flightData;

        public FlightService(IFlightData flightData)
        {
            _flightData = flightData;
        }

        public List<Flight> FilterFlights(string[] departureCodes, string arrivingAt, string departureDate)
        {
            var flights = _flightData.GetFlights().Where(f => f.TravalingTo == arrivingAt && f.DepartureDate >= Convert.ToDateTime(departureDate));

            if(departureCodes.Any())
            {
                flights = flights.Where(f => departureCodes.Contains(f.DepartingFrom));
            }

            return flights.ToList();
        }
    }
}
