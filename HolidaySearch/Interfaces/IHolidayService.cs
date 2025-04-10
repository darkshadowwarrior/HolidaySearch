using HolidaySearch.Models;

namespace HolidaySearch.Interfaces
{
    public interface IHolidayService
    {
        List<Holiday> Find(SearchCritera critera);
    }
}
