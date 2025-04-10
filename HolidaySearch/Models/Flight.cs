using Newtonsoft.Json;

namespace HolidaySearch.Models
{
    public class Flight
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("airline")]
        public string? Airline { get; set; }

        [JsonProperty("from")]
        public string? DepartingFrom { get; set; }

        [JsonProperty("to")]
        public string? TravalingTo { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("departure_date")]
        public DateTime DepartureDate { get; set; }
    }
}