using HolidaySearch.Models;

namespace HolidaySearch.Interfaces
{
    public interface IFlightData
    {
        List<Flight> GetFlights();
    }
}