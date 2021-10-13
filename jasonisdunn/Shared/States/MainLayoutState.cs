using System;
using jasonisdunn.Data;

namespace jasonisdunn.Shared
{
    public class MainLayoutState
    {
        private AssemblyVersion AssemblyVersion = new AssemblyVersion();
        public bool ppboolAssemblyVersion { get; set; }
        public bool ppFetchData { get; set; }

        public string ppAssemblyVersion { get; set; }
        public string ppstrAssemblyVersion { get; set; }

        private bool _boolAssemblyVersion;
        private string _AssemblyVersion;
        private string _strAssemblyVersion;

        private bool _boolFetchData;

        //private AssemblyVersion AssemblyVersion = new AssemblyVersion();

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();

        public void SetAssemblyVersionState( bool valueAssemblyVersion)
        {
            ppboolAssemblyVersion = _boolAssemblyVersion = valueAssemblyVersion;
        }
        public string  SetAssemblyVersion()
        {
            return ppAssemblyVersion = AssemblyVersion.pp_AssemblyVersion;
        }

        public void SetFetchDataState(bool valueFetchData)
        {
            ppFetchData = _boolFetchData = valueFetchData;
        }
    }
}
