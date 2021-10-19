using System;
using System.Linq;
using System.Threading.Tasks;

namespace jasonisdunn.Data
{
    public class GuidGeneratorService
    {
        private GuidGenerator guidGenerator = new GuidGenerator();
       
        public Task<GuidGenerator> CreateGuidAsync()
        {
            guidGenerator.Guid= GetUniqueKey();
            return Task.FromResult( new GuidGenerator
            {
               Guid = guidGenerator.Guid
            });
        }
        public static Guid GetUniqueKey()
        {
            Guid result = Guid.NewGuid();
            return result;
        }
    }
}
