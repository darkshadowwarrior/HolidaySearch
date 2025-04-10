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
            return _flightData.GetFlights().Where(f => departureCodes.Contains(f.DepartingFrom) && f.TravalingTo == arrivingAt && f.DepartureDate >= Convert.ToDateTime(departureDate)).ToList();                            
        }
    }
}
