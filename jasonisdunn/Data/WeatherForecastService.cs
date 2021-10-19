using System;
using System.Linq;
using System.Threading.Tasks;


namespace jasonisdunn.Data
{
    public class WeatherForecastService
    {
        const int twoweek = 14;
        WeatherForecast[] weatherForecast = new WeatherForecast[twoweek];
        private int intTemp, intSummary;

        private static readonly string[] Summaries = new[]
        {"Bracing","Freezing", "Frosty",  "Cold", "Warm", "Hot", "Sweltering", "Scorching"};

        public Task<WeatherForecast[]> CreateForecastAsync(DateTime startDate, bool _bool)
        {
            if (_bool)
            {
                for (int i = 0; i < weatherForecast.Length; i++)
                {
                    weatherForecast[i] = new WeatherForecast();
                }
                foreach (var item in weatherForecast)
                {
                    item.Date = startDate;
                    item.TemperatureC = 0;
                    item.Summary = Summaries[0];
                }
                return Task.FromResult(Enumerable.Range(1, twoweek).Select(index => new WeatherForecast
                {
                    Date = weatherForecast[index - 1].Date = startDate.AddDays(index),
                    TemperatureC = weatherForecast[index - 1].TemperatureC = newtemp(),
                    Summary = weatherForecast[index - 1].Summary = Summaries[intSummary]
                }).ToArray());
                  
            }
            else
            {
                return Task.FromResult(Enumerable.Range(1, twoweek).Select(index => new WeatherForecast
                {
                    Date = weatherForecast[index-1].Date,
                    TemperatureC = weatherForecast[index-1].TemperatureC,
                    Summary = weatherForecast[index-1].Summary
                }).ToArray());
            }
        }

        private int newtemp()
        {
            Random rnd = new Random();
            switch (intTemp = rnd.Next(-30, 50))
            {
                case int n when (n >= -30 && n < -20):
                    intSummary = 0;
                    break;
                case int n when (n >= -20 && n < -10):
                    intSummary = 1;
                    break;
                case int n when (n >= -10 && n < 0):
                    intSummary = 2;
                    break;
                case int n when (n >= 0 && n < 10):
                    intSummary = 3;
                    break;
                case int n when (n >= 10 && n < 20):
                    intSummary = 4;
                    break;
                case int n when (n >= 20 && n < 30):
                    intSummary = 5;
                    break;
                case int n when (n >= 30 && n < 40):
                    intSummary = 6;
                    break;
                case int n when (n >= 40):
                    intSummary = 7;
                    break;
            }
            return intTemp;
        }
    }
}