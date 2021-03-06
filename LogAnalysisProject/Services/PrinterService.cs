﻿using System;
using System.Collections.Generic;
using LogAnalysisProject.Models;

namespace LogAnalysisProject.Services
{
    public class PrinterService
    {
        public void PrintData(LogAnalysis userDataAnalysis)
        {
            PrintMainInformation(userDataAnalysis);
            PrintUsers(userDataAnalysis);
            PrintEntryPages(userDataAnalysis);
            PrintDeparturePages(userDataAnalysis);
            PrintTenFirsSessions(userDataAnalysis.TenFirstSessions);
        }

        private void PrintUsers(LogAnalysis userDataAnalysis)
        {
            Console.WriteLine("Lista użytkowników, i ich dane: ");
            userDataAnalysis.UserList.ForEach(u =>
            {
                Console.WriteLine($"Użytkownik: {u.Ip}, ilość sesji: {u.UserSession.Count.ToString()}, średnia ilość żądań: {u.AverageNumberOfRequest.ToString()}");
            });
            Console.WriteLine();
        }

        private void PrintMainInformation(LogAnalysis userDataAnalysis)
        {
            Console.WriteLine($"Ilość wszytskich sesji: {userDataAnalysis.TotalNumberOffSessions.ToString()}");
            Console.WriteLine();
            Console.WriteLine($"Najczęstsza strona startowa: {userDataAnalysis.MostCommonEntryPage.Key}; {userDataAnalysis.MostCommonEntryPage.Value.ToString()}");
            Console.WriteLine();
            Console.WriteLine($"Najczęstsza strona końcowa: {userDataAnalysis.MostCommonDeparturePage.Key}; {userDataAnalysis.MostCommonDeparturePage.Value.ToString()}");
            Console.WriteLine();
        }

        private void PrintEntryPages(LogAnalysis userDataAnalysis)
        {
            Console.WriteLine("Strony wejściowe: ");
            userDataAnalysis.EntryPageNumbers.ForEach(u =>
            {
                Console.WriteLine($"{u.Key}, : {u.Value.ToString()}");
            });
            Console.WriteLine();
        }

        private void PrintDeparturePages(LogAnalysis userDataAnalysis)
        {
            Console.WriteLine("Strony końcowe: ");
            userDataAnalysis.DeparturePageNumbers.ForEach(u =>
            {
                Console.WriteLine($"{u.Key}, : {u.Value.ToString()}");
            });
            Console.WriteLine();
        }

        private void PrintTenFirsSessions(List<Session> tenFirstSessions)
        {
            Console.WriteLine("10 pierwszych sesji");
            var x = 1;
            tenFirstSessions.ForEach(s =>
            {
                Console.WriteLine($"Sesja {x}: {s.UserIp}");
                s.Requests.ForEach(r =>
                {
                    Console.Write($"{r.Page} => ");
                });
                Console.WriteLine();
                x++;
            });
        }
    }
}