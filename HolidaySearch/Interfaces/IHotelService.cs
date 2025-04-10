using HolidaySearch.Models;

namespace HolidaySearch.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> FilterHotels(string arrivingAt, string departureDate, int lengthOfStay);
    }
}