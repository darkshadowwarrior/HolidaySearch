using HolidaySearch.Helpers;
using HolidaySearch.Interfaces;
using HolidaySearch.Models;

namespace HolidaySearch.Data
{
    public class HotelData : IHotelData
    {
        public List<Hotel> GetHotels()
        {
            return JsonFileReader.ReadFromFile<List<Hotel>>("hotels.json");
        }
    }
}
