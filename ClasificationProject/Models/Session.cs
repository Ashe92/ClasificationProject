using System;
using System.Collections.Generic;

namespace ClasificationProject.Models
{
    public class Session
    {
        public string PageLink { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int RequestedTimes { get; set; }
        public List<Line> SessionTimes { get; set; }

        public Session()
        {
            SessionTimes = new List<Line>();
        }
    }
}