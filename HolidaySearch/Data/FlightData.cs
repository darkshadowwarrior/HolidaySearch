using HolidaySearch.Helpers;
using HolidaySearch.Interfaces;
using HolidaySearch.Models;

namespace HolidaySearch.Data
{
    public class FlightData : IFlightData
    {
        public List<Flight> GetFlights()
        {
            return JsonFileReader.ReadFromFile<List<Flight>>("../../flights.json");
        }
    }
}
