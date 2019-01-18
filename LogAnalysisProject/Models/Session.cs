using System;
using System.Collections.Generic;

namespace LogAnalysisProject.Models
{
    public class Session
    {
        public string StartingPageLink { get; set; }
        public string DeparturePageLink { get; set; }
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

        public int NumberOfRequests { get; set; }
        public List<Request> Requests { get; }

        public Session()
        {
            Requests = new List<Request>();
        }

        private void GetSessionLength()
        {
            SessionLength = (EndDateTime - StartDateTime).TotalMinutes;
        }

    }
}