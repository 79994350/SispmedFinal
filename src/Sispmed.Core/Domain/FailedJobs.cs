using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class FailedJobs
    {
        public long Id { get; set; }
        public string Connection { get; set; }
        public string Queue { get; set; }
        public string Payload { get; set; }
        public string Exception { get; set; }
    }
}
