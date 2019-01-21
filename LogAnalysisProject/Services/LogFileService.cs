using LogAnalysisProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogAnalysisProject.Services
{
    public class LogFileService
    {

        private FileService _fileService;
        private FileService FileService => _fileService ?? (_fileService = new FileService());

        private int[,] _webStructure = null;

        private void GetWebStructure()
        {
            _webStructure = FileService.ReadCsvFile();
        }

        public List<User> CreateListOfUsers(List<Request> lines)
        {
            GetWebStructure();
            var groupedLines = lines.GroupBy(x => x.Ip);
            var users = new List<User>();
            foreach (var userSessions in groupedLines)
            {
                var user = new User();

                user.Ip = userSessions.Key;
                var userListOfSessions = lines.Where(x => x.Ip == user.Ip).OrderBy(y => y.Date).ToList();
                user.UserSession = CreateUserSessions(userListOfSessions);
                user.AverageNumberOfRequest = Math.Round((double)userListOfSessions.Count / (double)user.UserSession.Count, 2);
                users.Add(user);
            }

            return users;
        }

        private List<Session> CreateUserSessions(List<Request> requestLine)
        {
            var listOfSessions = new List<Session>();
            Request firstElement = null;
            var session = new Session();
            
            requestLine.ForEach(lastElement =>
            {
                if (firstElement == null)
                {
                    firstElement = lastElement;
                    session = StartNewSession(firstElement);
                }
                else
                {
                    var timeBetweenRequests = lastElement.Date - firstElement.Date;
                    if (CheckIfLineIsInSession(session, lastElement))
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

                        firstElement = null;
                    }
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
            session.UserIp = startRequest.Ip;
            session.StartDateTime = startRequest.Date;
            session.SessionStartingHour = startRequest.Date.Hour;
            session.StartingPageLink = startRequest.Page;
            session.Requests.Add(startRequest);
            return session;
        }

        private void EndSession(Session session)
        {
            session.NumberOfRequests = session.Requests.Count;

            var lastElement = session.Requests[session.NumberOfRequests - 1];
            session.DeparturePageLink = lastElement.Page;
            session.EndDateTime = lastElement.Date;
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
            if(_webStructure == null )
                GetWebStructure();
                
            return _webStructure[previousElement.PageId, lastElement.PageId] == 1;
        }
    }
}