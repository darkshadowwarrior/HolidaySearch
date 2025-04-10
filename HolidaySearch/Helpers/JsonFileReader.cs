using Newtonsoft.Json;

namespace HolidaySearch.Helpers
{
    public static class JsonFileReader
    {
        public static T ReadFromFile<T>(string fileName)
        {
            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, fileName);
            
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"The file at path {filePath} was not found.");

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json)!;
        }
    }
}

