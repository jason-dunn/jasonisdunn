using System;

namespace jasonisdunn.Data
{
    public class Status
    {

        public bool? LoggedIn { get; set; }

        public string? UserName { get; set; }

        public string? EmailAddress { get; set; }

        public Guid? Guid { get; set; }
    }
}
