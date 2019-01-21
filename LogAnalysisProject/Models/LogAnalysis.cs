using System;
using System.Collections.Generic;

namespace LogAnalysisProject.Models
{
    public class LogAnalysis
    {
        public List<User> UserList { get; set; }
        public int TotalNumberOffSessions { get; set; }
        public  List<KeyValuePair<string, int>> NumberOfSessionForUser { get; }
        public KeyValuePair<string, int> MostCommonEntryPage { get; set; }
        public KeyValuePair<string, int> MostCommonDeparturePage { get; set; }
        public List<KeyValuePair<string,int>> EntryPageNumbers { get; set; }
        public List<KeyValuePair<string, int>> DeparturePageNumbers { get; set; }
        public List<Session> AllSessions { get; }
        public List<Session> TenFirstSessions { get; set; }
        //charts
        public List<double> SessionsLengthsMinutes { get; set; }
        public List<int> NumberOfRequests { get; }
        public List<int> SessionStartingHour { get; }

        public LogAnalysis()
        {
            UserList = new List<User>();
            NumberOfSessionForUser = new List<KeyValuePair<string, int>>();
            MostCommonEntryPage = new KeyValuePair<string, int>();
            MostCommonDeparturePage = new KeyValuePair<string, int>();
            EntryPageNumbers =new List<KeyValuePair<string, int>>();
            DeparturePageNumbers = new List<KeyValuePair<string, int>>();
            AllSessions = new List<Session>();
            TenFirstSessions = new List<Session>();
            SessionsLengthsMinutes= new List<double>();
            NumberOfRequests = new List<int>();
            SessionStartingHour = new List<int>();
        }
    }
}