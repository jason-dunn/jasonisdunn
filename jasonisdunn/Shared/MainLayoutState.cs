using System;

namespace jasonisdunn.Shared
{
    public class MainLayoutState
    {
        private  bool _FetchData;
        public bool FetchData { get; set; }
        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
        public void SetFetchDataState(bool valueFetchData)
        {
            FetchData = _FetchData = valueFetchData;
        }
    }
}
