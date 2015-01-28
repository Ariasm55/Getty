using System;

namespace Collective.Model
{
    public class RecordReasonSummary
    {
        public string Reason { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime InitialDate { get; set; }
        public string TimeString { get; set; }
    }
}
