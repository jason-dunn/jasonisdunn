using System;
using jasonisdunn.Data;

namespace jasonisdunn.Shared
{
    public class MainState
    {
        private AssemblyVersion AssemblyVersion = new AssemblyVersion();
        private Increment Increment = new Increment();

        public bool ppboolAssemblyVersion { get; set; }
        public bool ppboolFetchData { get; set; }
        public bool ppboolCounter { get; set; }

        public string ppAssemblyVersion { get; set; }
        public string ppstrAssemblyVersion { get; set; }

        public int ppintCounter { get; set;}

        private bool _boolAssemblyVersion;
        private bool _boolFetchData;
        private bool _boolCounter;

        private string _AssemblyVersion;
        private string _strAssemblyVersion;

       

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
            ppboolFetchData = _boolFetchData = valueFetchData;
        }

        public void SetCounterState(bool valueCounter)
        {
            ppboolCounter = _boolCounter = valueCounter;
        }
    }
}
