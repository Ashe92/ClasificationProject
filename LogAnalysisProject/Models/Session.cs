using System;
using System.Collections.Generic;

namespace LogAnalysisProject.Models
{
    public class Session
    {
        public string PageLink { get; set; }
        public DateTime StartDateTime { get; set; }
        public double SessionLength { get; private set; }
        public int NumberOfRequests { get; set; }
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
        public List<Request> Requests { get; }

        public Session()
        {
            Requests = new List<Request>();
        }
    }
}