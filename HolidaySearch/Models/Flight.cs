namespace HolidaySearch.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string? DepartingFrom { get; set; }
        public string? TravalingTo { get; set; }
        public DateTime DepartureDate { get; set; }
        public double Price { get; set; }
        public string Airline { get; set; }
    }
}