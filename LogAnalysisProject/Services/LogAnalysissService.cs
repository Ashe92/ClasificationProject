using LogAnalysisProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogAnalysisProject.Services
{
    public class LogAnalysissService
    {
        
        private FileService _fileService;
        private FileService FileService => _fileService ?? (_fileService = new FileService());

        private int[,] _webStructure;

        public void RunClassification()
        {
            GetWebStructure();
            var fileLines = FileService.GetLogLines();
            var users = CreateListOfUsers(fileLines);

            Console.WriteLine("Done");
        }

        private void GetWebStructure()
        {
            _webStructure = FileService.ReadCsvFile();
        }

        private List<User> CreateListOfUsers(List<Request> lines)
        {
            var groupedLines = lines.GroupBy(x => x.Ip);
            var users = new List<User>();
            foreach (var userSessions in groupedLines)
            {
                var user = new User();

                user.Ip = userSessions.Key;
                var userListOfSessions = lines.Where(x => x.Ip == user.Ip).OrderBy(y => y.Date).ToList();
                user.UserSession = CreateUserSessions(userListOfSessions);
                user.AverageNumberOfRequest = Math.Round((double)userListOfSessions.Count / (double)user.UserSession.Count,2);
                users.Add(user);
            }

            return users;
        }

        private List<Session> CreateUserSessions(List<Request> requestLine)
        {
            var listOfSessions = new List<Session>();
            
            var firstElement = requestLine.First();
            var session = StartNewSession(firstElement);
            requestLine.ForEach(lastElement =>
            {
                var timeBetweenRequests = lastElement.Date - firstElement.Date;
                if(CheckIfLineIsInSession(session,lastElement))
                {
                    if (timeBetweenRequests.TotalMinutes > 0)
                    {
                        session.Requests.Add(lastElement);
                    }
                }
                else
                {
                    EndSession(session);
                    listOfSessions.Add(session);

                    firstElement = lastElement;
                    session = StartNewSession(firstElement);
                }
                if (requestLine[requestLine.Count - 1] == lastElement)
                {
                    EndSession(session);
                    listOfSessions.Add(session);
                }
            });
            return listOfSessions;

        }

        private Session StartNewSession(Request startRequest)
        {
            var session = new Session();
            session.StartDateTime = startRequest.Date;
            session.PageLink = startRequest.Page;
            session.Requests.Add(startRequest);
            return session;
        }

        private void EndSession(Session session)
        {
            session.RequestedTimes = session.Requests.Count;
            session.EndDateTime = session.Requests[session.RequestedTimes - 1].Date;
        }

        private bool CheckIfLineIsInSession(Session session, Request lastElement)
        {
            var inActualSession = false;
            var timeBetweenRequests = lastElement.Date - session.Requests.First().Date;
            if (timeBetweenRequests.TotalMinutes <= 15)
            {
                var previousElement = session.Requests.Last();
                inActualSession = CheckIfPreviousElementHasLink(lastElement, previousElement);
            }
            return inActualSession;
        }

        private bool CheckIfPreviousElementHasLink(Request lastElement, Request previousElement)
        {
            return _webStructure[previousElement.PageID, lastElement.PageID] == 1;
        }
    }
}
