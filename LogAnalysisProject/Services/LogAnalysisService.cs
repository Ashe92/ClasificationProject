using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LogAnalysisProject.Models;

namespace LogAnalysisProject.Services
{
    public class LogAnalysisService
    {
        private LogAnalysis LogAnalysis;

        public LogAnalysisService()
        {
            LogAnalysis = new LogAnalysis();
        }

        public LogAnalysis CreateLogAnalysis(List<User> usersData)
        {
            SetUserList(usersData);
            SetSessionsInfo(usersData);
            SetSessionPageInfo(usersData);
            return LogAnalysis;
        }

        private void SetSessionPageInfo(List<User> usersData)
        {
            var startingPages = new List<string>();
            var departurePages = new List<string>();
            
            usersData.ForEach(u =>
            {
                u.UserSession.ForEach(s =>
                {
                    LogAnalysis.NumberOfRequests.Add(new KeyValuePair<Session, int>(s, s.NumberOfRequests));
                    LogAnalysis.SessionStartingHour.Add(new KeyValuePair<Session, int>(s, s.StartDateTime.Hour));
                    startingPages.Add(s.StartingPageLink);
                    departurePages.Add(s.DeparturePageLink);
                });
            });

            var pageBottomMostRanks = departurePages.GroupBy(x => x).Select(departurePoint => new KeyValuePair<string, int>(departurePoint.Key, departurePoint.Count())).ToList();
            var pageTopMostRanks = startingPages.GroupBy(x => x).Select(startPoint => new KeyValuePair<string, int>(startPoint.Key, startPoint.Count())).ToList();

            LogAnalysis.EntryPageNumbers = pageTopMostRanks;
            LogAnalysis.DeparturePageNumbers = pageBottomMostRanks;
            LogAnalysis.MostCommonEntryPage = pageTopMostRanks.Aggregate((l, r) => l.Value > r.Value ? l : r);
            LogAnalysis.MostCommonDeparturePage = pageBottomMostRanks.Aggregate((l, r) => l.Value > r.Value ? l : r);
        }

        private void SetSessionsInfo(List<User> usersData)
        {
            usersData.ForEach(u =>
            {
                LogAnalysis.AverageNumberOfSessionForUser.Add(new KeyValuePair<string, int>(u.Ip,u.UserSession.Count));
                LogAnalysis.AllSessions.AddRange(u.UserSession);
                
            });
            LogAnalysis.TotalNumberOffSessions = LogAnalysis.AllSessions.Count;
        }
         
        private void SetUserList(List<User> usersData)
        {
            usersData.ForEach(u =>
            {
                LogAnalysis.UserList.Add(u.Ip);
            });
        }
    }
}