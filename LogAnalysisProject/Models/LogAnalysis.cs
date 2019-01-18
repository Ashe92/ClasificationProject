using System;
using System.Collections.Generic;

namespace LogAnalysisProject.Models
{
    public class LogAnalysis
    {
        public List<String> UserList { get; set; }
        public int TotalNumberOffSessions { get; set; }
        public  List<KeyValuePair<string, int>> AverageNumberOfSessionForUser { get; }
        public List<KeyValuePair<Session, int>> NumberOfRequests{ get; }
        public List<KeyValuePair<Session, int>> SessionStartingHour{ get; }
        public KeyValuePair<string, int> MostCommonEntryPage { get; set; }
        public KeyValuePair<string, int> MostCommonDeparturePage { get; set; }
        public List<KeyValuePair<string,int>> EntryPageNumbers { get; set; }
        public List<KeyValuePair<string, int>> DeparturePageNumbers { get; set; }
        public List<Session> AllSessions { get; }
        public List<Session> TenFirstSessions { get; set; }

        public LogAnalysis()
        {
            UserList = new List<string>();
            AverageNumberOfSessionForUser = new List<KeyValuePair<string, int>>();
            NumberOfRequests = new List<KeyValuePair<Session, int>>();
            SessionStartingHour = new List<KeyValuePair<Session, int>>();
            MostCommonEntryPage = new KeyValuePair<string, int>();
            MostCommonDeparturePage = new KeyValuePair<string, int>();
            EntryPageNumbers =new List<KeyValuePair<string, int>>();
            DeparturePageNumbers = new List<KeyValuePair<string, int>>();
            AllSessions = new List<Session>();
            TenFirstSessions = new List<Session>();
        }
    }
}