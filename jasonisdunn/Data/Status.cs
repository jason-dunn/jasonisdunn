using System;

namespace jasonisdunn.Data
{
    public class Status
    {

        public bool? LoggedIn { get; set; }

        public bool? Register { get; set; }

        public string? UserName { get; set; }

        public string? EmailAddress { get; set; }

        public string? Password { get; set; }

        public Guid? Guid { get; set; }

        
    }
}
