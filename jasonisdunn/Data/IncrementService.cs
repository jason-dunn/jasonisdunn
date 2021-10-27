using System.Linq;
using System.Threading.Tasks;


namespace jasonisdunn.Data
{
    public class IncrementService
    {
        Increment increment = new Increment();
        public int ppintCounter { get; set; }
        private int intCounter;

        public Task<Increment> SetCounterAsync(int value)
        {
            return Task.FromResult(new Increment
            {
                Counter = value
            });
        }
        public Task<Increment> GetCounterAsync(bool _bool, int value)
        {
            if (_bool)
                return Task.FromResult(new Increment
            {
                Counter = ppintCounter = increment.Counter
            });
            else
            {
                return Task.FromResult(new Increment
                {
                    Counter = ppintCounter = value
                });
            }
        }
        }
}
