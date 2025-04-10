namespace Search
{
    public class Tests
    {
        private HolidaySearch _search;

        [SetUp]
        public void Setup()
        {
            _search = new HolidaySearch();
        }

        [Test]
        public void CustomerOne_SearchReturns_Expected_Holiday()
        {
            var payload = new SearchCritera() { From = "MAN", To = "AGP", DepartureDate = "2023/07/01", Duration = 7 };

            var results = _search.Find(payload);

            Assert.That(results, Is.Not.Null);
            Assert.That(results.First().Flight.Id, Is.EqualTo(2));
            Assert.That(results.First().Hotel.Id, Is.EqualTo(9));
        }

        [Test]
        public void CustomerTwo_SearchReturns_Expected_Holiday()
        {
            var payload = new SearchCritera() { From = "London", To = "PMI", DepartureDate = "2023/06/15", Duration = 10 };

            var results = _search.Find(payload);

            Assert.That(results, Is.Not.Null);
            Assert.That(results.First().Flight.Id, Is.EqualTo(6));
            Assert.That(results.First().Hotel.Id, Is.EqualTo(5));
        }
    }
}