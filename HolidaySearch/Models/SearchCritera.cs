﻿namespace HolidaySearch.Models
{
    public class SearchCritera
    {
        public required string[] From { get; set; }
        public required string To { get; set; }
        public required string DepartureDate { get; set; }
        public required int Duration { get; set; }
    }
}