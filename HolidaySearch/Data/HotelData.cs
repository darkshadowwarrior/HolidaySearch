using HolidaySearch.Helpers;
using HolidaySearch.Models;

namespace HolidaySearch.Data
{
    public class HotelData
    {
        public static List<Hotel> GetHotels()
        {
            return JsonFileReader.ReadFromFile<List<Hotel>>("../../hotels.json");
        }
    }
}
