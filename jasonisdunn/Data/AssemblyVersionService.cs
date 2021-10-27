using System.Reflection;
using System.Dynamic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace jasonisdunn.Data
{
    public class AssemblyVersionService
    {

        private string _AssemblyVersion;
        private string _strAssemblyVersion;

        public Task<AssemblyVersion>  GetstrAssemblyVersion()
        {
            Assembly _Assembly = Assembly.GetExecutingAssembly();
            //TODO 1
            //if debug|release
            //AssemblyConfigurationAttribute configurationAttribute = _Assembly.GetCustomAttribute<AssemblyConfigurationAttribute>();
            AssemblyInformationalVersionAttribute versionAttribute = _Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            _AssemblyVersion = versionAttribute.InformationalVersion;
            _strAssemblyVersion = "Version " + _AssemblyVersion;
            dynamic result = new ExpandoObject();
            result.version = _AssemblyVersion;
            string versionAsText = JsonConvert.SerializeObject(result);
            return Task.FromResult(new AssemblyVersion
            {
                pp_strAssemblyVersion = _strAssemblyVersion
            });
        }
    }
}
