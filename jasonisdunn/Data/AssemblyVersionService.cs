using System.Reflection;
using System.Dynamic;
using Newtonsoft.Json;

namespace jasonisdunn.Data
{
    public class AssemblyVersionService
    {
        AssemblyVersion assemblyVersion = new AssemblyVersion();
        private string _AssemblyVersion;
        private string _strAssemblyVersion;
        public string GetstrAssemblyVersion()
        {
            Assembly _Assembly = Assembly.GetExecutingAssembly();
            AssemblyConfigurationAttribute configurationAttribute = _Assembly.GetCustomAttribute<AssemblyConfigurationAttribute>();
            //TODO : 1
            //
            //Remove condition ( | configurationAttribute.Configuration == "Release")
            if (configurationAttribute.Configuration == "Debug" | configurationAttribute.Configuration == "Release")
            {
                AssemblyInformationalVersionAttribute versionAttribute = _Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
                _AssemblyVersion = versionAttribute.InformationalVersion;
                _strAssemblyVersion = "Version " + _AssemblyVersion;
                dynamic result = new ExpandoObject();
                result.version = _AssemblyVersion;
                string versionAsText = JsonConvert.SerializeObject(result);
            }
            else
            {
                //TODO : 2
                //
                //Write "Release" _AssemblyVersion to database
            }

            return _strAssemblyVersion;
        }
    }
}
