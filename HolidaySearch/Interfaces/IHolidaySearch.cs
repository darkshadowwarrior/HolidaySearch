using HolidaySearch.Models;
using Search;

namespace HolidaySearch.Interfaces
{
    public interface IHolidaySearch
    {
        List<Holiday> Find(SearchCritera critera);
    }
}
