This is a technical test for OTB

Create a simple Holiday Search library that will return the best holidays with hotels and flight avilable from teh given datasets

Assumtions have been made

1) Any london airport is a list of london airport codes
2) Any airport is an empty array dipicting no filter requirements for airports

The project has been broken down into 

HolidaysSearch/
  Models
  Services
  Interfaces
  Data Layer
  HolidaySearch

HolidaySearch.Tests
  FlightServiceTests
  HotelServiceTests
  HolidaySearchTests

As the SearchCritera model has set the contract requirements no error handling has been done in this simple search library

Given the Data Layer could be swaped out for some other datasouce no mapping from data model to domina model has been performed however there is no reason why this can't be done at a later date
