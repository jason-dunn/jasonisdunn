using System;
using System.Linq;
using System.Threading.Tasks;

namespace jasonisdunn.Data
{
    public class WeatherForecastService
    {

        private int intTemp, intSummary;

        private static readonly string[] Summaries = new[]
        {
        "Bracing","Freezing", "Frosty",  "Cold", "Warm", "Hot", "Sweltering", "Scorching"
    };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = newtemp(),
                Summary = Summaries[intSummary],
            }).ToArray());
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