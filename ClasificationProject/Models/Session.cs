using System;
using System.Collections.Generic;

namespace ClasificationProject.Models
{
    public class Session
    {
        public string PageLink { get; set; }
        public DateTime StartDateTime { get; set; }
        public double SessionLength { get; private set; }

        private DateTime _endDateTime;

        public DateTime EndDateTime
        {
            get => _endDateTime;
            set
            {
                _endDateTime = value;
                GetSessionLength();
            }
        }

        private void GetSessionLength()
        {
            SessionLength = (EndDateTime - StartDateTime).TotalMinutes;
        }

        public int RequestedTimes { get; set; }
        public List<Line> SessionTimes { get; }

        public Session()
        {
            SessionTimes = new List<Line>();
        }
    }
}