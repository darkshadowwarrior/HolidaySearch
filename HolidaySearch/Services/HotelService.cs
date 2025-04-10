using HolidaySearch.Interfaces;
using HolidaySearch.Models;

namespace HolidaySearch.Services
{
    public class HotelService : IHotelService
    {
        private IHotelData _hotelData;

        public HotelService(IHotelData hotelData)
        {
            _hotelData = hotelData;
        }

        public List<Hotel> FilterHotels(string arrivingAt, string departureDate, int lengthOfStay)
        {
            return _hotelData.GetHotels().Where(h => h.LocalAirports.Contains(arrivingAt) && h.ArrivalDate >= Convert.ToDateTime(departureDate) && h.Nights == lengthOfStay).ToList();
        }
    }
}
