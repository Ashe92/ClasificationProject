using System;
using System.Collections.Generic;

namespace LogAnalysisProject.Models
{
    public class LogAnalysis
    {
        public List<String> UserList { get; set; }
        public int TotalNumberOffSessions { get; set; }
        public  KeyValuePair<string,decimal> AverageSessionForUsers { get; set; }
        public List<int> NumberOfRequests{ get; set; }
        public List<int> SessionStartingHour{ get; set; }
        public string MostCommonEntryPage { get; set; }
        public string MostCommonDeparturePage { get; set; }
        public KeyValuePair<string,int> EntryPageNumbers { get; set; }
        public KeyValuePair<string, int> DeparturePageNumbers { get; set; }
        public List<Session> AllSessions { get; set; }
        public List<Session> TenFirstSessions { get; set; }
    }
}