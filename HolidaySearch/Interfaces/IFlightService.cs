using HolidaySearch.Models;

namespace HolidaySearch.Interfaces
{
    public interface IFlightService
    {
        List<Flight> FilterFlights(string[] departureCodes, string arrivingAt, string departureDate);
    }
}
