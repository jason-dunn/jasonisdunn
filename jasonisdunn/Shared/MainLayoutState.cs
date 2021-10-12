using System;
using System.Reflection;
using System.Dynamic;
using Newtonsoft.Json;
//using System.Threading.Tasks;

namespace jasonisdunn.Shared
{
    public class MainLayoutState
    {
        
        public bool FetchData { get; set; }
        public string AssemblyVersion { get; set; }

        private bool _FetchData;
        private string _AssemblyVersion;
        private string _strAssemblyVersion;

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();

        private Type type= typeof(int);

        public void SetFetchDataState(bool valueFetchData)
        {
            FetchData = _FetchData = valueFetchData;
        }

        //public async Task<string> GetAssembly()
        public string GetAssemblyVersion()
        {
            Assembly _Assembly = Assembly.GetExecutingAssembly();
            AssemblyConfigurationAttribute configurationAttribute = _Assembly.GetCustomAttribute<AssemblyConfigurationAttribute>();
            //private string _ConfigurationAttribute = configurationAttribute.Configuration();
            Console.WriteLine(configurationAttribute.Configuration=="Debug");
            if (configurationAttribute.Configuration == "Debug")
            {
                AssemblyInformationalVersionAttribute versionAttribute = _Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
                _AssemblyVersion = versionAttribute.InformationalVersion;
                _strAssemblyVersion = "Debug Assembly Version " +_AssemblyVersion;
                dynamic result = new ExpandoObject();
                result.version =  _AssemblyVersion;
                string versionAsText = JsonConvert.SerializeObject(result);
            }
            else
            {
                //TODO
                //Write "Release" _AssemblyVersion to database
                _strAssemblyVersion = "Release Assembly Version " + " Not Verified";
                //_strAssemblyVersion = "Release Assembly Version" + " -----      Not Verified       -----";
            }

            return _strAssemblyVersion;
        }
    }
}
