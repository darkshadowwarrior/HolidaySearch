﻿namespace HolidaySearch.Models
{
    public class Holiday
    {
        public required Flight Flight { get; set; }
        public required Hotel Hotel { get; set; }
        public decimal TotalPrice { get; set; }
    }
}