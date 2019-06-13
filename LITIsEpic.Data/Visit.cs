using System;

namespace LITIsEpic.Data
{
    public class Visit
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public DateTime Date { get; set; }
    }

    public class VisitCounts
    {
        public string IpAddress { get; set; }
        public int Count { get; set; }
    }
}
