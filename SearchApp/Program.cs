// See https://aka.ms/new-console-template for more information

using HolidaySearch.Data;
using HolidaySearch.Models;
using HolidaySearch.Services;

Console.WriteLine("Please enter your departure airport codes comma delimited");
var airportDepartureCodes = Console.ReadLine().Split(",");

Console.WriteLine("Please enter your departure date (format: 2022/11/10)");
var departuredate = Console.ReadLine();

Console.WriteLine("Please enter your stay duration");
var duration = Console.ReadLine();

Console.WriteLine("Please enter your arrival airport code");
var arrivalCode = Console.ReadLine();

var search = new HolidayService(new FlightService(new FlightData()), new HotelService(new HotelData())).Find(new SearchCritera()
                                                {
                                                    DepartureDate = departuredate,
                                                    Duration = Convert.ToInt32(duration),
                                                    From = airportDepartureCodes,
                                                    To = arrivalCode
}
                                        );

Console.WriteLine("\n\n---------------------------------------------------------------------");
Console.WriteLine($"Total Price: {search.First().TotalPrice}");
Console.WriteLine($"Flight Id: {search.First().Flight.Id}");
Console.WriteLine($"Flight departing from: {search.First().Flight.DepartingFrom}");
Console.WriteLine($"Flight travelling to: {search.First().Flight.TravalingTo}");
Console.WriteLine($"Flight price: {search.First().Flight.Price}");
Console.WriteLine($"Hotel Id: {search.First().Hotel.Id}");
Console.WriteLine($"Hotel name: {search.First().Hotel.Name}");
Console.WriteLine($"Hotel price per night {search.First().Hotel.PricePerNight}");
Console.WriteLine("---------------------------------------------------------------------\N\N");