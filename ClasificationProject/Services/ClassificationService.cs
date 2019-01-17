﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using ClasificationProject.Models;

namespace ClassificationProject.Services
{
    public class ClassificationService
    {
        
        private FileService _fileService;
        private FileService FileService => _fileService ?? (_fileService = new FileService());

        public void RunClassification()
        {
            var fileLines = FileService.GetLines();
            var users = CreateClassification(fileLines);
            var counted = 0;
            users.ForEach(u => { u.UserSession.ForEach(us => { counted += us.SessionTimes.Count; }); });
            Console.Write($"Ilosc linii przed: {fileLines.Count.ToString()}, ilosc linii po: {counted.ToString()}");
            

        }

        public List<User> CreateClassification(List<Line> lines)
        {
            var groupedLines = lines.GroupBy(x => x.Ip);
            var users = new List<User>();
            foreach (var userSessions in groupedLines)
            {
                var user = new User();

                user.UserSession = new List<Session>();
                user.Ip = userSessions.Key;
                var userListOfSessions = lines.Where(x => x.Ip == user.Ip).OrderBy(y => y.Date).ToList();
                user.UserSession = CreateUserSessions(userListOfSessions);
                user.AverageNumberOfRequest = Math.Round((double)userListOfSessions.Count / (double)user.UserSession.Count,2);
                users.Add(user);
            }

            return users;
        }

        private List<Session> CreateUserSessions(List<Line> requestLine)
        {
            var listOfSessions = new List<Session>();
            var session = new Session();
            var firstElement = requestLine.First();
            session.StartDateTime = firstElement.Date;
            session.SessionTimes.Add(firstElement);
            Line lastElement = null;
            requestLine.ForEach(r =>
            {
                lastElement = r;
                var timeBetweenRequests = lastElement.Date - firstElement.Date;
                if (timeBetweenRequests.TotalMinutes <= 15)
                {
                    if (timeBetweenRequests.TotalMinutes > 0)
                    {
                        session.SessionTimes.Add(lastElement);
                    }
                }
                else
                {
                    session.RequestedTimes = session.SessionTimes.Count;
                    session.StartDateTime = firstElement.Date;
                    session.EndDateTime = session.SessionTimes[session.RequestedTimes - 1].Date;
                    listOfSessions.Add(session);
                    //new session
                    session = new Session();
                    firstElement = lastElement;
                    session.SessionTimes.Add(firstElement);
                    
                }
                if (requestLine[requestLine.Count - 1] == lastElement)
                {
                    session.RequestedTimes = session.SessionTimes.Count;
                    session.StartDateTime = firstElement.Date;
                    session.EndDateTime = session.SessionTimes[session.RequestedTimes - 1].Date;
                    listOfSessions.Add(session);
                }
            });
            return listOfSessions;

        }
    }
}
