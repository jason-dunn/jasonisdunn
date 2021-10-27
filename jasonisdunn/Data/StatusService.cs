using System;
using System.Linq;
using System.Threading.Tasks;

namespace jasonisdunn.Data
{
    public class StatusService
    {
        Status status = new Status();

        public Task<Status> CreateStatusAsync(bool _bool, Status valueStatus = null)
        {
            if (_bool)
            {
                    status.LoggedIn = false;
                    status.UserName = "";
                    status.EmailAddress = "";
                    status.Guid = new Guid();
               
                return Task.FromResult( new Status
                {
                    LoggedIn = status.LoggedIn,
                    UserName = status.UserName,
                    EmailAddress = status.EmailAddress,
                    Guid = status.Guid
                });
            }
            else
            {
                return Task.FromResult( new Status
                {
                    LoggedIn = valueStatus.LoggedIn,
                    UserName = valueStatus.UserName,
                    EmailAddress = valueStatus.EmailAddress,
                    Guid = valueStatus.Guid
                });
            }
        }
    }
}
