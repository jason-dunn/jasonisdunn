using System;
using jasonisdunn.Data;

namespace jasonisdunn.Shared.States
{
    public class MainState
    {
        static Status Status = new Status();
        private AssemblyVersion AssemblyVersion = new AssemblyVersion();
        private Increment Increment = new Increment();

        private bool _boolAssemblyVersion;
        private bool _boolFetchData;
        private bool _boolCounter;
        private bool _boolLoggedIn;
        private bool _boolRegister;
        private bool? _LoggedIn = Status.LoggedIn;

        private string _AssemblyVersion;
        private string _strAssemblyVersion;
        private string _strRegister;
        private string? _UserName = Status.UserName;
        private string? _EmailAddress = Status.EmailAddress;

        private Guid? _Guid = Status.Guid;

        public Status ppstatusStatus { get; set; }

        public bool ppboolAssemblyVersion { get; set; }
        public bool ppboolFetchData { get; set; }
        public bool ppboolCounter { get; set; }
        public bool ppboolLoggedIn { get; set; }
        public bool? ppboolRegister { get; set; }

        public string ppAssemblyVersion { get; set; }
        public string ppstrAssemblyVersion { get; set; }
        public string? ppstrUserName { get; set; }
        public string? ppstrEmailAddress { get; set; }
        public string? ppstrPassword { get; set; }
        public string? ppstrRegister { get; set; }

        public int ppintCounter { get; set;}

        public Guid? ppguidGuid { get; set; }


        //private AssemblyVersion AssemblyVersion = new AssemblyVersion();

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();

        public void SetAssemblyVersionState(bool valueAssemblyVersion)
        {
            ppboolAssemblyVersion = _boolAssemblyVersion = valueAssemblyVersion;
        }
        public string  SetAssemblyVersion()
        {
            return ppAssemblyVersion = AssemblyVersion.pp_AssemblyVersion;
        }
        public string SetRegister(string valueRegister)
        {
            return ppstrRegister = _strRegister = valueRegister;
        }

        public void SetRegisterState(bool valueRegister)
        {
            ppboolRegister = _boolRegister = valueRegister;
        }

        public void SetLoggedInState(bool valueLoggedIn)
        {
            ppboolLoggedIn = _boolLoggedIn = valueLoggedIn;
        }

        public void SetFetchDataState(bool valueFetchData)
        {
            ppboolFetchData = _boolFetchData = valueFetchData;
        }

        public void SetCounterState(bool valueCounter)
        {
            ppboolCounter = _boolCounter = valueCounter;
        }

        //public void SetStatus()
        //{
        //   ppstatusStatus = Status;
        //   ppstatusStatus.LoggedIn= Status.LoggedIn = ppboolLoggedIn;
        //   ppstatusStatus.UserName =Status.UserName = ppstrUserName;
        //   ppstatusStatus.EmailAddress = Status.EmailAddress = ppstrEmailAddress;
        //   ppstatusStatus.Guid= Status.Guid = ppguidGuid;
        //}
    }
}
