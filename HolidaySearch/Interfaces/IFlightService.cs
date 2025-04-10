using HolidaySearch.Models;

namespace HolidaySearch.Interfaces
{
    public interface IFlightService
    {
        List<Flight> FilterFlights(string departFrom, string arrivingAt, string departureDate);
    }
}
