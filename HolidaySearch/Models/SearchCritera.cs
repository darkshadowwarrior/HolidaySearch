namespace Search
{
    public class SearchCritera
    {
        public required string[] From { get; set; }
        public required string To { get; set; }
        public required string DepartureDate { get; set; }
        public int Duration { get; set; }
    }
}