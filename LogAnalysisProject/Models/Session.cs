using System;
using System.Collections.Generic;

namespace LogAnalysisProject.Models
{
    public class Session
    {
        public string UserIp{ get; set; }
        public string StartingPageLink { get; set; }
        public string DeparturePageLink { get; set; }
        public DateTime StartDateTime { get; set; }
        public double SessionLengthInMinutes { get; private set; }
        public int SessionStartingHour { get; set; }
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
            SessionLengthInMinutes = (EndDateTime - StartDateTime).TotalMinutes;
        }

    }
}